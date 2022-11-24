using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BestellungController : ControllerBase
    {
        private readonly IBestellungDienst _bestellungDienst;

        public BestellungController(IBestellungDienst bestellungDienst)
        {
            _bestellungDienst = bestellungDienst;
        }

        [HttpPost]
        public async Task<ActionResult<DienstAntwort<bool>>> BestellungAufgeben()
        {
            var resultat = await _bestellungDienst.BestellungAufgebenAsync();
            return Ok(resultat);
        }
    }
}
