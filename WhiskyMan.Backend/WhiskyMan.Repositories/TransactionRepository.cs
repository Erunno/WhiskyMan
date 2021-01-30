using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.Transaction;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly IDataContextWrapper dataContext;
        private readonly IMapper mapper;

        public TransactionRepository(
            IDataContextWrapper dataContext,
            IMapper mapper
            )
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task AddTransaction(TransactionForAdditionForRepo transaction)
        {
            var transactionEntity = mapper.Map<Transaction>(transaction);
            await dataContext.AddEntityAsync(transactionEntity);
            await dataContext.SaveChangesAsync();
        }
    }
}
