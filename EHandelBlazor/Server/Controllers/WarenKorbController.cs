using EHandelBlazor.Shared.Modelle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
    }
}
