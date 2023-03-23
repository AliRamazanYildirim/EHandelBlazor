using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdresseController : ControllerBase
    {
        private readonly IAdresseDienst _adresseDienst;

        public AdresseController(IAdresseDienst adresseDienst)
        {
            _adresseDienst = adresseDienst;
        }
        [HttpGet]
        public async Task<ActionResult<DienstAntwort<Adresse>>> GeheZurAdresse()
        {
            return await _adresseDienst.GeheZurAdresseAsync();
        }
        [HttpPost]
        public async Task<ActionResult<DienstAntwort<Adresse>>> AdresseAktualisierenOderAddieren(Adresse adresse)
        {
            return await _adresseDienst.AdresseAktualisierenOderAddierenAsync(adresse);
        }
    }
}
