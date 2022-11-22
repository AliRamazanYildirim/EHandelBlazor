using EHandelBlazor.Shared.Modelle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Validierungen
{
    public class BenutzerPasswortÄndernValidator : AbstractValidator<BenutzerPasswortÄndern>
    {
        public BenutzerPasswortÄndernValidator()
        {
            RuleFor(p => p.Passwort).NotEmpty().WithMessage("Ihr Passwort darf nicht leer sein.")
                   .MinimumLength(8).WithMessage("Ihre Passwortlänge muss mindestens 8 betragen.")
                   .MaximumLength(50).WithMessage("Ihre Passwortlänge darf 16 nicht überschreiten.");
            RuleFor(p => p.Passwort).NotEqual(p => p.PasswortBestätigen).WithMessage("Die Passwörter stimmen nicht überein");

        }
    }
}
