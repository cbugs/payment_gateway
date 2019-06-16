using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaymentGateway.Api.Controllers;
using PaymentGateway.Api.Models;
using PaymentGateway.Service.Interface;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Tests
{
    public class PaymentControllerMakePayment
    {
        [Fact]
        public async Task PaymentGatewayAPI_MakePayment_WhenCalled_ReturnsSuccess()
        {
            // Arrange
            var paymentModel = new PaymentModel()
            {
                UserId = Guid.Parse("e43a794b-9ba5-46d8-8f74-1da699b84093"),
                Amount = 9000,
                Details = "Book",
                PaymentMethod = "CreditCard",
                Values = "{'CardNumber':'test','FullName':'Bruce','Address':'Gotham','ExpiryMonth':'12','ExpiryYear':'25','CVC':'test'}"
            };

            var mockPaymentService = new Mock<IPaymentService>();
            var mockUserService = new Mock<IUserService>();
            var mockLogger = new Mock<ILogger<PaymentController>>();

            var controller = new PaymentController(mockPaymentService.Object, mockUserService.Object, mockLogger.Object);

            controller.ControllerContext = new ControllerContext
            {
                HttpContext = new DefaultHttpContext
                {
                    User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
                    {
                        new Claim("MerchantId", "e43a794b-9ba5-46d8-8f74-1da699b84092")
                    }))
                }
            };

            // Act
            var actionResult = await controller.MakePayment(paymentModel);
            var result = actionResult.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal("Success", result.Value);
        }
    }
}
