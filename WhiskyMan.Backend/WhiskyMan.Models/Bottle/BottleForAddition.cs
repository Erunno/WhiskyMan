using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.Bottle
{
    public record BottleForAddition
    {
        public int BottleDescriptionId { get; set; }
        public int Amount_ml { get; set; }
        public decimal ShotPrice { get; set; }
        public decimal BottlePrice { get; set; }
        public int WastePercent { get; set; }
        public List<int> OwnerIds { get; set; }
    }
    class Validator_BottleForAddition : AbstractValidator<BottleForAddition>
    {
        public Validator_BottleForAddition()
        {
            RuleFor(x => x.BottleDescriptionId).NotNull();
            RuleFor(x => x.Amount_ml).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.BottlePrice).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.ShotPrice).NotNull().GreaterThanOrEqualTo(0);
            RuleFor(x => x.WastePercent).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            RuleFor(x => x.OwnerIds).NotNull().NotEmpty();
        }
    }
}
