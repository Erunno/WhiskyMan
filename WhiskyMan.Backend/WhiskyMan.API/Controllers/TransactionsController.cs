using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Interfaces.Transactions;
using WhiskyMan.BusinessLogic.Policy;
using WhiskyMan.BusinessLogic.Policy.Transactions;
using WhiskyMan.Entities.Auth;
using WhiskyMan.Models.Transaction;

namespace WhiskyMan.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionFacade transactionFacade;

        public TransactionsController(
            ITransactionFacade transactionFacade
            )
        {
            this.transactionFacade = transactionFacade;
        }

        [HttpPost("add-one")]
        [Authorize(Policy = TransactionPolicies.AddOwnTransaction)]
        public async Task<IActionResult> AddTransaction(TransactionForAdditionDto transaction)
        {
            await transactionFacade.AddTransaction(transaction);
            return Ok(StatusCodes.Status201Created);
        }
    }
}
