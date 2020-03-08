using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using stock_api.Domain.Entities;

namespace stock_api.Service.Validators
{
    public class HistoryValidator : AbstractValidator<History>
    {
        public HistoryValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.IdStock)
                .NotEqual(0).WithMessage("Is necessary inform the Stock Id")
                .NotNull().WithMessage("Is necessary inform the Stock Id");

            RuleFor(c => c.Max)
                .NotEqual(0).WithMessage("Is necessary inform the Max value.")
                .GreaterThan(0).WithMessage("Max value can't be negative.")
                .NotNull().WithMessage("Is necessary inform the Max value.");

            RuleFor(c => c.Min)
                .NotEqual(0).WithMessage("Is necessary inform the Min value.")
                .GreaterThan(0).WithMessage("Min value can't be negative.")
                .NotNull().WithMessage("Is necessary inform the Min value.");

            RuleFor(c => c.Openning)
                .NotEqual(0).WithMessage("Is necessary inform the Openning value.")
                .GreaterThan(0).WithMessage("Openning value can't be negative.")
                .NotNull().WithMessage("Is necessary inform the Openning value.");

            RuleFor(c => c.Closing)
               .NotEqual(0).WithMessage("Is necessary inform the Closing value.")
               .GreaterThan(0).WithMessage("Closing value can't be negative.")
               .NotNull().WithMessage("Is necessary inform the Closing value.");

            RuleFor(c => c.Timestamp)
               .NotEmpty().WithMessage("Is necessary inform the Timestamp")              
               .NotNull().WithMessage("Is necessary inform the Timestamp");
        }
    }
}
