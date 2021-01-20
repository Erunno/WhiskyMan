using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;

namespace WhiskyMan.Models.BottleDescription
{
    public record BottleDescriptionForAddition
    {
        public string Name { get; set; }
        public string Distillery { get; set; }
        public int? Age { get; set; }
        public decimal Voltage { get; set; }
        public string PictureUrl { get; set; }
        public string DescriptionText { get; set; }
        public string Region { get; set; }
        public List<long> TagIds { get; set; }
    }

    class Validator_UserForRegister : AbstractValidator<BottleDescriptionForAddition>
    {
        public Validator_UserForRegister()
        {
            RuleFor(x => x.Name).NotNull().Length(2, EntitiesConfig.NameLength);
            RuleFor(x => x.Distillery).NotNull().Length(2, EntitiesConfig.NameLength);
            RuleFor(x => x.Age).GreaterThanOrEqualTo(0);
            RuleFor(x => x.PictureUrl).NotNull().Length(2, EntitiesConfig.UrlLength);
            RuleFor(x => x.Region).Length(2, EntitiesConfig.NameLength);
            RuleFor(x => x.Voltage).NotNull().GreaterThanOrEqualTo(0).LessThanOrEqualTo(100);
            RuleFor(x => x.DescriptionText).NotNull().Length(2, EntitiesConfig.DescriptionLength);
        }
    }
}
