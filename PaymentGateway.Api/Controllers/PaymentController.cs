using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Api.Abstract;
using PaymentGateway.Api.Abstract.Factory;
using Microsoft.Extensions.Logging;
using PaymentGateway.Api.Models;
using System.Linq;
using System.Threading.Tasks;
using PaymentGateway.Api.Utility;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Service.Interfaces;

namespace PaymentGateway.Api.Controllers
{

    /// <summary>
    /// The Payment Gateway API.
    /// Contains endpoints for the API such as retrieve UserId, Make Payments, or get list of payments per user.
    /// </summary>

    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(Roles = "Merchant")]
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;
        private readonly IUserService _userService;
        private readonly ILogger<PaymentController> _logger;

        public PaymentController(IPaymentService paymentService, IUserService userService, ILogger<PaymentController> logger)
        {
            _logger = logger;
            _paymentService = paymentService;
            _userService = userService;
        }

        /// <summary>
        /// Retrieves User Id.
        /// If User Id is empty in request params, user is created and User Id returned.
        /// If User Id and User Email re not empty in request params, user is updated if user id exists and email has changed.
        /// If User Id is empty in request params and email alerady exists, corresponding User Id is returned. 
        /// </summary>
        /// <param name="user"></param>
        /// <returns>
        /// Generated User Id.
        /// </returns>
        [HttpPut]
        public async Task<ActionResult<string>> GetUser(UserModel user)
        {
            try
            {
                Guid userID = await _userService.RetrieveUser(user.UserId, user.UserEmail);
                _logger.LogInformation("User Create/Get Success");
                return Ok(userID);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "User Create/Get Error");
                return StatusCode(500, "Internal server error");
            }
        }

        /// <summary>
        /// The API to make payments by users.
        /// </summary>
        /// <param name="paymentModel"></param>
        /// <returns>
        /// The status of the payment made.
        /// </returns>
        [HttpPost]
        public async Task<ActionResult<string>> MakePayment(PaymentModel paymentModel)
        {
            try
            {
                var paymentObject = new PaymentObject().Create((PaymentMethods)Enum.Parse(typeof(PaymentMethods), paymentModel.PaymentMethod, true), paymentModel.Values);
                paymentObject.Amount = paymentModel.Amount;
                paymentObject.Details = paymentModel.Values;

                var bankResponse = paymentObject.Process();

                // Get MerchantId from JWT Claim
                var merchantClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "MerchantId");
                if (merchantClaim == null) return StatusCode(400, "Request Invalid");

                var merchantId = Guid.Parse(merchantClaim.Value);
                var payment = new Payment()
                {
                    PaymentAmount = paymentModel.Amount,
                    PaymentDetails = paymentModel.Values,
                    UserId = paymentModel.UserId,
                    MerchantId = merchantId,
                    PaymentStatus = bankResponse.status
                };


                await _paymentService.AddPayment(payment);

                if (!bankResponse.status)
                {
                    return BadRequest("Transaction Not Approved");
                }

                _logger.LogInformation("Payment Success");
                //save payment made
                return Ok("Success");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "Payment Error");
                return StatusCode(500, e.Message);
            }

        }

        /// <summary>
        /// Get the list of payments done by user of authenticated merchant
        /// </summary>
        /// <param name="id"></param>
        /// <returns>
        /// List of payments
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<string>> GetPayments()
        {
            var merchantClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == "MerchantId");
            if (merchantClaim == null) return StatusCode(400, "Request Invalid");

            var merchantId = Guid.Parse(merchantClaim.Value);
            var payments = await _paymentService.GetPaymentsByMerchant(merchantId);
            return Ok(payments);
        }

    }
}