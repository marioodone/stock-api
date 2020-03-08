using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using stock_api.Domain.Entities;

namespace stock_api.Service.Validators
{
    public class StockValidator : AbstractValidator<Stock>
    {
        public StockValidator()
        {
            RuleFor(c => c)
                .NotNull()
                .OnAnyFailure(x =>
                {
                    throw new ArgumentNullException("Can't found the object.");
                });

            RuleFor(c => c.Code)
                .NotEmpty().WithMessage("Is necessary inform the Code.")
                .NotNull().WithMessage("Is necessary inform the Code.");

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary inform the Name.")
                .NotNull().WithMessage("Is necessary inform the Name.");

        }
    }
}
