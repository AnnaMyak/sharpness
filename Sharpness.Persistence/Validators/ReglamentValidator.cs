using FluentValidation;
using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Validators
{
    public class ReglamentValidator: AbstractValidator <Reglament>
    {
        public ReglamentValidator()
        {
            RuleFor(x => x.Titel).Must(BeUniqueName).WithMessage("Please give a another titel for the reglament. The titel already exists");
        }

        private bool BeUniqueName(string Titel)
        {
            return new DataContext().WSIs.FirstOrDefault(x => x.Titel == Titel) == null;
        }
    }
}

