using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.Transaction
{
    public record TransactionForAdditionDto
    {
        public long? BuyerId { get; set; }
        public long? BottleId { get; set; }
        public int? Amount_ml { get; set; }
    }

    public class Validator_TransactionForAddition : AbstractValidator<TransactionForAdditionDto>
    {
        public Validator_TransactionForAddition()
        {
            RuleFor(x => x.BuyerId).NotNull();
            RuleFor(x => x.BottleId).NotNull();
            RuleFor(x => x.Amount_ml).NotNull().GreaterThanOrEqualTo(0);
        }
    }
}
