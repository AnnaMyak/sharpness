using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using Sharpness.Persistence.Entities;

namespace Sharpness.Persistence.Validators
{
    public class StainValidator: AbstractValidator<Stain>
    {
        public StainValidator()
        {
            RuleFor(x => x.Name).Must(BeUniqueName).WithMessage("The stain already exists");
        }

        private bool BeUniqueName(string Name)
        {
            return new DataContext().Stains.FirstOrDefault(x => x.Name == Name) == null;
        }
    }
}
