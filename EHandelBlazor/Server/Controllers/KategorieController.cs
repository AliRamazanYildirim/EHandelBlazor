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
        [HttpGet("admin"), Authorize(Roles ="Admin")]
        public async Task<ActionResult<DienstAntwort<List<Kategorie>>>> GeheZurAdminKategorien()
        {
            var resultat = await _kategorieDienst.GeheZurAdminKategorienAsync();
            return Ok(resultat);
        }
        [HttpDelete("admin/{id}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<DienstAntwort<List<Kategorie>>>> LöschenKategorie(int ID)
        {
            var resultat = await _kategorieDienst.LöschenKategorieAsync(ID);
            return Ok(resultat);
        }
        [HttpPost("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<DienstAntwort<List<Kategorie>>>> HinzufügenKategorie(Kategorie kategorie)
        {
            var resultat = await _kategorieDienst.HinzufügenKategorieAsync(kategorie);
            return Ok(resultat);
        }
        [HttpPut("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<DienstAntwort<List<Kategorie>>>> AktualisierenKategorie(Kategorie kategorie)
        {
            var resultat = await _kategorieDienst.AktualisierenKategorieAsync(kategorie);
            return Ok(resultat);
        }
    }
}
