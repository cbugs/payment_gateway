using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaymentGateway.Api.Controllers;
using PaymentGateway.Api.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using PaymentGateway.Domain.Entities;
using PaymentGateway.Service.Interfaces;
using Xunit;

namespace PaymentGateway.Tests
{
    public class PaymentControllerGetPayments
    {
        [Fact]
        public async Task PaymentGatewayAPI_MakePayment_WhenCalled_ReturnsUserPayments()
        {
            // Arrange
            var merchantId = Guid.Parse("e43a794b-9ba5-46d8-8f74-1da699b84093");
            var payments = new List<Payment>
            {
                new Payment()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = new Guid(),
                    UserId = new Guid(),
                    MerchantId = merchantId,
                    PaymentAmount = 1000,
                    PaymentDetails = "Book"
                },
                new Payment()
                {
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Id = new Guid(),
                    UserId = new Guid(),
                    MerchantId = merchantId,
                    PaymentAmount = 2000,
                    PaymentDetails = "Laptop"
                }
            };

            var mockPaymentService = new Mock<IPaymentService>();
            var mockUserService = new Mock<IUserService>();
            var mockLogger = new Mock<ILogger<PaymentController>>();

            mockPaymentService.Setup(ps => ps.GetPaymentsByMerchant(merchantId))
                .ReturnsAsync(payments);

            var controller = new PaymentController(mockPaymentService.Object, mockUserService.Object, mockLogger.Object)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                        {
                            new Claim("MerchantId", "e43a794b-9ba5-46d8-8f74-1da699b84093")
                        }))
                    }
                }
            };


            // Act
            var actionResult = await controller.GetPayments();
            var result = actionResult.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(payments, result.Value);
        }
    }
}
