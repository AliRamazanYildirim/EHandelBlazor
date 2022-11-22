using EHandelBlazor.Shared.Modelle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarenKorbController : ControllerBase
    {
        private readonly IWarenKorbDienst _warenKorbDienst;

        public WarenKorbController(IWarenKorbDienst warenKorbDienst)
        {
            _warenKorbDienst = warenKorbDienst;
        }
        [HttpPost("produkte")]
        public async Task<ActionResult<DienstAntwort<List<AntwortDesWarenKorbProduktes>>>> GeheZurAntwortDerWarenKorbProdukte(List<WarenKorbArtikel> warenKorbArtikel)
        {
            var resultat = await _warenKorbDienst.GeheZurAntwortDerWarenKorbProdukteAsync(warenKorbArtikel);
            return Ok(resultat);
        }
        [HttpPost]
        public async Task<ActionResult<DienstAntwort<List<AntwortDesWarenKorbProduktes>>>> WarenKorbArtikelSpeichern(List<WarenKorbArtikel> warenKorbArtikel)
        {
            var benutzerID = int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var resultat = await _warenKorbDienst.WarenKorbArtikelSpeichernAsync(warenKorbArtikel, benutzerID);
            return Ok(resultat);
        }
    }
}
