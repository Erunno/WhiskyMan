using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.Transaction;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddTransaction(TransactionForAdditionForRepo transaction);
    }
}
