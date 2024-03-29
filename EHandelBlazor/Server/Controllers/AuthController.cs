﻿namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthDienst _authDienst;

        public AuthController(IAuthDienst authDienst)
        {
            _authDienst = authDienst;
        }
        [HttpPost("registrierung")]
        public async Task<ActionResult<DienstAntwort<int>>> Registrieren(BenutzerRegistrieren anfrage)
        {
            var antwort = await _authDienst.RegistrierenAsync(
            new Benutzer
            {
                Email = anfrage.Email
            },
            anfrage.Passwort);

            if(!antwort.Erfolg)
            {
                return BadRequest(antwort);
            }
            return Ok(antwort);
        }
        [HttpPost("anmeldung")]
        public async Task<ActionResult<DienstAntwort<string>>>Anmeldung(BenutzerAnmeldung anfrage)
        {
            var antwort = await _authDienst.AnmeldungAsync(anfrage.Email, anfrage.Passwort);
            if(!antwort.Erfolg)
            {
                return BadRequest(antwort);
            }
            return Ok(antwort);
        }
        [HttpPost("ändere-passwort"), Authorize]
        public async Task<ActionResult<DienstAntwort<bool>>> ÄnderenPasswort([FromBody] string neuesPasswort)
        {
            var benutzerID = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var antwort = await _authDienst.PasswortÄndernAsync(int.Parse(benutzerID), neuesPasswort);

            if(!antwort.Erfolg)
            {
                return BadRequest(antwort);
            }
            return Ok(antwort);
        }
    }
}
