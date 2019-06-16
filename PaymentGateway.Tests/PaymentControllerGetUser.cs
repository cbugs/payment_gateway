using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using PaymentGateway.Api.Controllers;
using PaymentGateway.Api.Models;
using PaymentGateway.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace PaymentGateway.Tests
{
    public class PaymentControllerGetUser
    {
        [Fact]
        public async Task PaymentGatewayAPI_GetUser_WhenCalled_ReturnsUserID()
        {
            // Arrange
            var userModel = new UserModel()
            {
                UserId = Guid.Parse("e43a794b-9ba5-46d8-8f74-1da699b84093"),
                UserEmail = "test@test.com"
            };

            var mockPaymentService = new Mock<IPaymentService>();
            var mockUserService = new Mock<IUserService>();
            var mockLogger = new Mock<ILogger<PaymentController>>();
            mockUserService.Setup(us => us.RetrieveUser(userModel.UserId, userModel.UserEmail))
                .ReturnsAsync(userModel.UserId);
            var controller = new PaymentController(mockPaymentService.Object, mockUserService.Object, mockLogger.Object);

            // Act
            var actionResult = await controller.GetUser(userModel);
            var result = actionResult.Result as OkObjectResult;

            // Assert
            Assert.NotNull(result);
            Assert.Equal(200, result.StatusCode);
            Assert.Equal(userModel.UserId, result.Value);
        }
    }
}
