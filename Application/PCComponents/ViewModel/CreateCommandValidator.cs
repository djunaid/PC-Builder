using Application.PCComponents.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PCComponents.ViewModel
{
    internal class CreateCommandValidator : AbstractValidator<CreateComponentCommand>
    {
        public CreateCommandValidator()
        {
            RuleFor(x => x.Tags).NotNull();
            RuleFor(x => x.Name).NotEmpty().NotNull();
            RuleFor(x => x.Price).GreaterThanOrEqualTo(0);
            RuleFor(x => x.Type).NotEmpty().NotNull();
        }
    }
}
