using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.BusinessLogic.Interfaces.Policy;
using WhiskyMan.Models.Transaction;

namespace WhiskyMan.BusinessLogic.Policy.Transactions
{
    public class AddOwnTransactionRequirement : IAuthorizationRequirement
    {
    }

    public class AddOwnTransactionHandler : AuthorizationHandler<AddOwnTransactionRequirement>
    {
        private readonly IRequestBodyAccessor bodyAccessor;

        public AddOwnTransactionHandler(IRequestBodyAccessor bodyAccessor)
        {
            this.bodyAccessor = bodyAccessor;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AddOwnTransactionRequirement requirement)
        {
            var transaction = await bodyAccessor.GetRequestBody<TransactionForAdditionDto>();
            var loggedUserId = int.Parse(context.User.FindFirst(ClaimTypes.NameIdentifier).Value);


            if (transaction.BuyerId == loggedUserId)
                context.Succeed(requirement);
        }
    }
}
