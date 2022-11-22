using EHandelBlazor.Shared.Modelle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Validierungen
{
    public class BenutzerAnmeldungValidator : AbstractValidator<BenutzerAnmeldung>
    {
        public BenutzerAnmeldungValidator()
        {
            RuleFor(b => b.Email).NotEmpty().WithMessage("E-Mail ist erforderlich.");
            RuleFor(p => p.Passwort).NotEmpty().WithMessage("Ihr Passwort darf nicht leer sein.");

        }
    }
}
