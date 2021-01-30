using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.Bottle;
using WhiskyMan.Models.Transaction;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.BusinessLogic.Transactions.Operations
{
    public class GetTransactionPriceOperation
    {
        private const decimal ShotSize_ml = 20m;

        private readonly IBottleRepository bottleRepo;

        public GetTransactionPriceOperation(IBottleRepository bottleRepo)
        {
            this.bottleRepo = bottleRepo;
        }

        public decimal Run(TransactionForAdditionDto transaction, BottleForPriceModel bottle)
        {
            var usersSpecialPrice =
                bottle.SpecialPrices
                    .FirstOrDefault(sp => sp.UserId == transaction.BuyerId);

            if (usersSpecialPrice is not null)
                return GetPrice(amount: transaction.Amount_ml.Value, shotPrice: usersSpecialPrice.Price);

            var userIsOwner =
                bottle.Owners.Contains(transaction.BuyerId.Value);

            if (userIsOwner)
                return GetOwnerPrice(amount: transaction.Amount_ml.Value, bottle);

            return GetPrice(amount: transaction.Amount_ml.Value, bottle.ShotPrice);
        }

        public async Task<decimal> Run(TransactionForAdditionDto transaction)
        {
            var bottle = await bottleRepo.GetBottleForPriceModel(transaction.BottleId.Value);
            return Run(transaction, bottle);
        }

        private decimal GetOwnerPrice(int amount, BottleForPriceModel bottle)
        {
            var realAmount = bottle.Amount_ml * (100 - bottle.WastePercent) / 100m;
            var numOfShotInBottle = realAmount / ShotSize_ml;
            var shotPrice = bottle.BottlePrice / numOfShotInBottle;

            return GetPrice(amount, shotPrice);
        }

        private decimal GetPrice(int amount, decimal shotPrice)
        {
            var numOfShots = amount / ShotSize_ml;
            return shotPrice * numOfShots;
        }
    }
}
