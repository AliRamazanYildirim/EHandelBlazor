using EHandelBlazor.Shared.Modelle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Validierungen
{
    public class BearbeitungProduktValidator:AbstractValidator<Produkt>
    {
        public BearbeitungProduktValidator()
        {
            RuleFor(p => p.Title).NotEmpty().WithMessage("Title ist erforderlich.");
            RuleFor(p => p.Bezeichnung).NotEmpty().WithMessage("Bezeichnung Url ist erforderlich.");
        }
    }
}
