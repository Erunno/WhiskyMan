using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.Transaction;

namespace WhiskyMan.BusinessLogic.Interfaces.Transactions
{
    public interface ITransactionFacade
    {
        Task AddTransaction(TransactionForAdditionDto transaction);
    }
}
