using Autofac;
using Autofac.Extras.Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Transactions.Operations;
using WhiskyMan.Models.Bottle;
using WhiskyMan.Models.Transaction;
using WhiskyMan.Repositories.Interfaces;
using WhiskyMan.Repositories.Mapping;

namespace WhiskyMan.BusinessLogic.Tests.Transactions.Operations
{
    public class GetTransactionPriceOperationTest
    {
        private BottleForPriceModel GetBottle()
            => new BottleForPriceModel
            {
                BottlePrice = 3500,
                Amount_ml = 1000,
                WastePercent = 30,
                ShotPrice = 50,
                Owners = new List<long> { 1, 2, 3 },
                SpecialPrices = new List<SpecialPriceInBottleModel>
                {
                    new SpecialPriceInBottleModel { UserId = 11, Price = 10 },
                    new SpecialPriceInBottleModel { UserId = 1, Price = 6 },
                }
            };

        [Test]
        [TestCase(1, 20, 6, Description = "Owner with special price ==> it should be computed based on special price")]
        [TestCase(1, 50, 15, Description = "Owner with special price ==> it should be computed based on special price (2,5 shots)")]

        [TestCase(2, 20, 100, Description = "Owner without special price ==> real price should be computed")]
        [TestCase(2, 50, 250, Description = "Owner without special price ==> real price should be computed (2,5 shots)")]

        [TestCase(11, 20, 10, Description = "Not owner with special price ==> special price should be used")]
        [TestCase(11, 50, 25, Description = "Not owner with special price ==> special price should be used (2,5 shots)")]

        [TestCase(42, 20, 50, Description = "Regular customer ==> price from bottle should be used")]
        [TestCase(42, 50, 125, Description = "Regular customer ==> price from bottle should be used (2,5 shots)")]
        public void ComputePriceBasedOnBottle(
            int buyerId,
            int amount,
            decimal expectedPrice
            )
        {
            // arrange
            using var mock = AutoMock.GetStrict(builder =>
                 builder.RegisterInstance(MapperProvider.GetMapper()));

            mock.Mock<IBottleRepository>()
                .Setup(repo => repo.GetBottleForPriceModel(100))
                .Returns(Task.FromResult(GetBottle()));

            var transaction = new TransactionForAdditionDto
            {
                BuyerId = buyerId,
                Amount_ml = amount,
                BottleId = 100
            };

            var operation = mock.Create<GetTransactionPriceOperation>();

            // act
            decimal actualPrice = operation.Run(transaction).Result;

            // assert
            Assert.AreEqual(expectedPrice, actualPrice, $"Computed price is different from expected price (expected: {expectedPrice}, actual: {actualPrice})");
        }

    }
}
