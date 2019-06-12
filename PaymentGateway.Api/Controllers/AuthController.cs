using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaymentGatewayData.Repository;
using PaymentGatewayData.Models;
using Microsoft.Extensions.Logging;
using PaymentGatewayApi.Models;
using Microsoft.Extensions.Options;
using PaymentGatewayData.Repository.Interface;

namespace PaymentGatewayApi.Controllers
{
    [Route("v1/")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMerchantRepository _merchantRepository;
        private readonly ILogger<AuthController> _logger;
        private readonly SecurityKeyConfiguration _securityKeyConfiguration;

        public AuthController(IMerchantRepository merchantRepository, ILogger<AuthController> logger, IOptions<SecurityKeyConfiguration> securityKeyConfiguration)
        {
            _logger = logger;
            _merchantRepository = merchantRepository;
            _securityKeyConfiguration = securityKeyConfiguration.Value;
        }

        /// <summary>
        /// JWT Token Authentication for Merchant Role
        /// </summary>
        /// <param name="merchantRequest"></param>
        /// <returns>JWT Token</returns>
        [HttpPost]
        [Route("token")]
        public ActionResult GetToken(MerchantModel merchantModel)
        {
            var merchant = _merchantRepository.Login(merchantModel.Username, merchantModel.Password);
            if (merchant == null) { _logger.LogWarning("Unauthorised Access"); return Unauthorized(); }
            try
            {
                //security key
                string securityKey = _securityKeyConfiguration.Value;
                //symmetric security key
                var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                //signing credentials
                var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

                //add claims
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Role, "Merchant"));
                claims.Add(new Claim("MerchantId", merchant.MerchantId.ToString()));

                //create token
                var token = new JwtSecurityToken(
                    issuer: "test",
                    audience: "readers",
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: signingCredentials,
                    claims: claims
                    );

                //return token
                return Ok(new JwtSecurityTokenHandler().WriteToken(token));
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Token Access Error");
                return StatusCode(500, e);
            }
        }
    }
}