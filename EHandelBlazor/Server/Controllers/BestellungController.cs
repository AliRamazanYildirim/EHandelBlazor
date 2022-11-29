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


        [HttpGet]
        public async Task<ActionResult<DienstAntwort<List<BestellÜbersichtDüo>>>> GeheZurBestellungen()
        {
            var resultat = await _bestellungDienst.GeheZurBestellungenAsync();
            return Ok(resultat);
        }

        [HttpGet("{bestellID}")]
        public async Task<ActionResult<DienstAntwort<List<BestellDetailsDüo>>>> GeheZurBestellDetails(int bestellID)
        {
            var resultat = await _bestellungDienst.GeheZurBestellDetailsAsync(bestellID);
            return Ok(resultat);
        }
    }
}
