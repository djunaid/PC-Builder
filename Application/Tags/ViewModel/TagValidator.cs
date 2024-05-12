using Application.Tags.Commands;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Tags.ViewModel
{
    public class TagValidator : AbstractValidator<CreateTagCommand>
    {
        public TagValidator() {

            RuleFor(x => x.Name).Length(3,25);
            RuleFor(x => x.Value).Length(0, 100);
            
        }
    }
}
