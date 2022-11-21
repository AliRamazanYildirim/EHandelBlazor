﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection.Metadata.Ecma335;
using System.Security.Claims;
using System.Security.Cryptography;

namespace EHandelBlazor.Server.Dienste.AuthDienst
{
    public class AuthDienst : IAuthDienst
    {
        private readonly DatenKontext _kontext;
        private readonly IConfiguration _configuration;

        public AuthDienst(DatenKontext kontext, IConfiguration configuration)
        {
            _kontext = kontext;
            _configuration = configuration;
        }

        public async Task<bool> BenutzerExistiertAsync(string email)
        {
            if(await _kontext.Benutzer.AnyAsync(benutzer=>benutzer.Email.ToLower().Equals(email.ToLower())))
            {
                return true;
            }
            return false;
        }
        private void ErstellenPasswortHash(string passwort, out byte[] passwortHash, out byte[] passwortSalz) 
        {
            using(var hashHersteller=new HMACSHA512())
            {
                passwortSalz = hashHersteller.Key;
                passwortHash = hashHersteller.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwort));
            }
        }

        public async Task<DienstAntwort<int>> RegistrierenAsync(Benutzer benutzer, string passwort)
        {
            if(await BenutzerExistiertAsync(benutzer.Email))
            {
                return new DienstAntwort<int> 
                {
                    Erfolg = false, 
                    Nachricht = "Benutzer existiert bereits." 
                };
            }
            ErstellenPasswortHash(passwort, out byte[] passwortHash, out byte[] passwortSalz);
            benutzer.PasswortHash = passwortHash;
            benutzer.PasswortSalz = passwortSalz;

            _kontext.Benutzer.Add(benutzer);
            await _kontext.SaveChangesAsync();

            return new DienstAntwort<int>
            {
                Daten = benutzer.ID,
                Nachricht= "Die Registrierung ist erfolgreich :)"
            };
        }

        public async Task<DienstAntwort<string>> AnmeldungAsync(string email, string passwort)
        {
            var antwort = new DienstAntwort<string>();
            var benutzer = await _kontext.Benutzer.
                FirstOrDefaultAsync(b => b.Email.ToLower().Equals(email.ToLower()));
            if(benutzer == null)
            {
                antwort.Erfolg = false;
                antwort.Nachricht = "Benutzer wurde nicht gefunden.";
            }
            else if(!VerifizierenPasswortHash(passwort, benutzer.PasswortHash, benutzer.PasswortSalz))
            {
                antwort.Erfolg = false;
                antwort.Nachricht = "Falsches Passwort.";
            }
            else
            {
                antwort.Daten = ErstellenToken(benutzer);
            }
            
            return antwort;
        }
        private bool VerifizierenPasswortHash(string passwort, byte[] passwortHash, byte[] passwortSalz)
        {
            using (var hashHersteller = new HMACSHA512(passwortSalz))
            {
                var berechneteHash = hashHersteller.ComputeHash(System.Text.Encoding.UTF8.GetBytes(passwort));
                return berechneteHash.SequenceEqual(passwortHash);
            }
        }

        private string ErstellenToken(Benutzer benutzer)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, benutzer.ID.ToString()),
                new Claim(ClaimTypes.Name, benutzer.Email)
            };

            var schlüssel = new SymmetricSecurityKey(System.Text.Encoding.UTF8
                .GetBytes(_configuration.GetSection("AppEinstellungen:Token").Value));

            var creds = new SigningCredentials(schlüssel, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims:claims,
                expires:DateTime.Now.AddDays(1),
                signingCredentials:creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }
    }
}
