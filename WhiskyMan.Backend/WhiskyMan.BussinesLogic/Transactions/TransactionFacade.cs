using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Interfaces.Transactions;
using WhiskyMan.BusinessLogic.Transactions.Operations;
using WhiskyMan.Models.Transaction;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.BusinessLogic.Transactions
{
    public class TransactionFacade : ITransactionFacade
    {
        private readonly GetTransactionPriceOperation getTransactionPriceOperation;
        private readonly IMapper mapper;
        private readonly ITransactionRepository repo;

        public TransactionFacade(
            GetTransactionPriceOperation getTransactionPriceOperation,
            IMapper mapper,
            ITransactionRepository repo
            )
        {
            this.getTransactionPriceOperation = getTransactionPriceOperation;
            this.mapper = mapper;
            this.repo = repo;
        }

        public async Task AddTransaction(TransactionForAdditionDto transaction)
        {
            var transactionModelForRepo = mapper.Map<TransactionForAdditionForRepo>(transaction);
            transactionModelForRepo.Price = await getTransactionPriceOperation.Run(transaction);

            await repo.AddTransaction(transactionModelForRepo);
        }
    }
}
