using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class ProduktArtController : ControllerBase
    {
        private readonly IProduktArtDienst _produktArtDienst;

        public ProduktArtController(IProduktArtDienst produktArtDienst)
        {
            _produktArtDienst = produktArtDienst;
        }
        [HttpGet]
        public async Task<ActionResult<DienstAntwort<List<ProduktArt>>>> GeheZurAlleProduktArten()
        {
            var antwort = await _produktArtDienst.GeheZurAlleProduktArtenAsync();
            return Ok(antwort);
        }

    }
}
