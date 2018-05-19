using FluentValidation;
using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Validators
{
    public class TissueValidator: AbstractValidator<Tissue>
    {
        public TissueValidator()
        {
            RuleFor(x => x.Name).Must(BeUniqueName).WithMessage("The tissue already exists");
        }

        private bool BeUniqueName(string Name)
        {
            return new DataContext().Tissues.FirstOrDefault(x => x.Name == Name) == null;
        }
    }
}
