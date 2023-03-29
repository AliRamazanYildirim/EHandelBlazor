using EHandelBlazor.Shared.Modelle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Validierungen
{
    public class ProduktÄnderungValidator : AbstractValidator<Produkt>
    {
        public ProduktÄnderungValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Title ist erforderlich.");
        }
    }
}
