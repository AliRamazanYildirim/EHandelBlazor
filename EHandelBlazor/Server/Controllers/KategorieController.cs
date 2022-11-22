using EHandelBlazor.Shared.Modelle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorieController : ControllerBase
    {
        private readonly IKategorieDienst _kategorieDienst;

        public KategorieController(IKategorieDienst kategorieDienst)
        {
            _kategorieDienst = kategorieDienst;
        }
        [HttpGet]
        public async Task<ActionResult<DienstAntwort<List<Kategorie>>>>GeheZurAlleKategorien()
        {
            var resultat = await _kategorieDienst.GeheZurAlleKategorienAsync();
            return Ok(resultat);
        }
    }
}
