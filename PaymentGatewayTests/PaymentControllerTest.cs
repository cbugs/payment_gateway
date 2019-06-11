using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PaymentGatewayApi.Controllers;
using PaymentGatewayApi.Models;
using PaymentGatewayApi.Abstract;
using PaymentGatewayApi.Abstract.Factory;
using PaymentGatewayData.Models;
using PaymentGatewayData.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace PaymentGatewayTests
{
    public class PaymentControllerTest
    {

        public PaymentControllerTest()
        {
        }

        [Fact]
        public void PaymentMethodFactory_WhenCalled_ReturnsCorrectType()
        {
            PaymentModel requestModel_CreditCard = new PaymentModel()
            {
                Amount = 1000,
                PaymentMethod = "CreditCard",
                UserId = Guid.Parse("93adb84b-0be7-4d03-af9d-91a5ff2bbc3q"),
                Values = "{\"CardNumber\":\"testc\",\"FullName\":\"testf\",\"Address\":\"testa\",\"ExpiryMonth\":\"testem\",\"ExpiryYear\":\"testey\",\"CVC\":\"testcsv\"}"
            };
            // Act
            var paymentType_CreditCard = new PaymentObject().Create((PaymentMethods)Enum.Parse(typeof(PaymentMethods), requestModel_CreditCard.PaymentMethod, true), requestModel_CreditCard.Values);

            // Assert
            Assert.IsType<CreditCard>(paymentType_CreditCard);


            PaymentModel requestModel_EWallet = new PaymentModel()
            {
                Amount = 1000,
                PaymentMethod = "EWallet",
                UserId = Guid.Parse("93adb84b-0be7-4d03-af9d-91a5ff2bbc3q"),
                Values = "{\"Username\":\"testc\",\"Password\":\"testf\"}"
            };
            // Act
            var paymentType_EWallet = new PaymentObject().Create((PaymentMethods)Enum.Parse(typeof(PaymentMethods), requestModel_EWallet.PaymentMethod, true), requestModel_EWallet.Values);

            // Assert
            Assert.IsType<EWallet>(paymentType_EWallet);

        }

    }
}
