using FluentValidation;
using Sharpness.Persistence.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sharpness.Persistence.Validators
{
    public class OrganValidator:AbstractValidator<Organ>
    {
        public OrganValidator()
        {
            RuleFor(x => x.Name).Must(BeUniqueName).WithMessage("The organ already exists");
        }

        private bool BeUniqueName(string Name)
        {
            return new DataContext().Organs.FirstOrDefault(x => x.Name == Name) == null;
        }
    }
}
