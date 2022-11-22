using EHandelBlazor.Shared.Modelle;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EHandelBlazor.Shared.Validierungen
{
    public class BenutzerRegistrierenValidator : AbstractValidator<BenutzerRegistrieren>
    {
        public BenutzerRegistrierenValidator()
        {
            RuleFor(b => b.Email).NotEmpty().WithMessage("E-Mail ist erforderlich.");
            RuleFor(b => b.Email).EmailAddress().WithMessage("Bitte geben Sie eine gültige E-Mail-Adresse an.");
            RuleFor(p => p.Passwort).NotEmpty().WithMessage("Ihr Passwort darf nicht leer sein.")
                    .MinimumLength(8).WithMessage("Ihre Passwortlänge muss mindestens 8 betragen.")
                    .MaximumLength(16).WithMessage("Ihre Passwortlänge darf 16 nicht überschreiten.");
            RuleFor(b => b.Passwort).Matches(@"[A-Z]+").WithMessage("Ihr Passwort muss mindestens einen Großbuchstaben enthalten.");
            RuleFor(b => b.Passwort).Matches(@"[a-z]+").WithMessage("Ihr Passwort muss mindestens einen Kleinbuchstaben enthalten.");
            RuleFor(b => b.Passwort).Matches(@"[0-9]+").WithMessage("Ihr Passwort muss mindestens eine Nummer enthalten.");
            RuleFor(b => b.Passwort).Matches(@"[\!\?\*\.]*$").WithMessage("Ihr Passwort muss mindestens ein (!? *.) enthalten.");
            RuleFor(x => x.PasswortBestätigen).NotEmpty().WithMessage("Bitte bestätigen Sie Ihr Passwort.");

        }
    }
}
