using PaymentGateway.Api.Models;
using PaymentGateway.Api.Abstract;
using PaymentGateway.Api.Abstract.Factory;
using System;
using Xunit;

namespace PaymentGateway.Tests
{
    public class PaymentControllerTest
    {
        [Fact]
        public void PaymentMethodFactory_WhenCalled_ReturnsCorrectType()
        {
            // Arrange
            PaymentModel requestModel_CreditCard = new PaymentModel()
            {
                Amount = 1000,
                PaymentMethod = "CreditCard",
                UserId = Guid.Parse("e43a794b-9ba5-46d8-8f74-1da699b84092"),
                Details = "Book",
                Values = "{\"CardNumber\":\"testc\",\"FullName\":\"testf\",\"Address\":\"testa\",\"ExpiryMonth\":\"testem\",\"ExpiryYear\":\"testey\",\"CVC\":\"testcsv\"}"
            };
            // Act
            var paymentType_CreditCard = new PaymentObject().Create((PaymentMethods)Enum.Parse(typeof(PaymentMethods), requestModel_CreditCard.PaymentMethod, true), requestModel_CreditCard.Values);

            // Assert
            Assert.IsType<CreditCard>(paymentType_CreditCard);

            // Arrange
            PaymentModel requestModel_EWallet = new PaymentModel()
            {
                Amount = 1000,
                PaymentMethod = "EWallet",
                Details = "Laptop",
                UserId = Guid.Parse("e43a794b-9ba5-46d8-8f74-1da699b84092"),
                Values = "{\"Username\":\"testc\",\"Password\":\"testf\"}"
            };
            // Act
            var paymentType_EWallet = new PaymentObject().Create((PaymentMethods)Enum.Parse(typeof(PaymentMethods), requestModel_EWallet.PaymentMethod, true), requestModel_EWallet.Values);

            // Assert
            Assert.IsType<EWallet>(paymentType_EWallet);
        }
    }
}
