using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.Transaction;

namespace WhiskyMan.Repositories.Tests.Mapping
{
    class TransactionMapsTest : MappingTest
    {
        [Test]
        public void TransactionForAdditionDto_TransactionForAdditionForRepo()
            => TestMapping<TransactionForAdditionDto, TransactionForAdditionForRepo>(
                input: GetTransactionForAdditionDto(),
                expected: GetTransactionForAdditionForRepo(),

                // don't check following properties
                nameof(TransactionForAdditionForRepo.Price)
                );


        [Test]
        public void TransactionForAdditionForRepo_Transaction()
            => TestMapping<TransactionForAdditionForRepo, Transaction>(
                input: GetTransactionForAdditionForRepo(),
                expected: GetTransaction(),

                // don't check following properties
                nameof(Transaction.CreationTime)
                );

        private TransactionForAdditionDto GetTransactionForAdditionDto()
            => new TransactionForAdditionDto
            {
                BuyerId = 3,
                BottleId = 5,
                Amount_ml = 30,
            };

        private TransactionForAdditionForRepo GetTransactionForAdditionForRepo()
            => new TransactionForAdditionForRepo
            {
                BuyerId = 3,
                BottleId = 5,
                Amount_ml = 30,
                Price = 100
            };

        private Transaction GetTransaction()
            => new Transaction
            {
                BuyerId = 3,
                BottleId = 5,
                Amount_ml = 30,
                Price = 100
            };
    }
}
