﻿namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduktController : ControllerBase
    {
        private readonly IProduktDienst _produktDienst;

        public ProduktController(IProduktDienst produktDienst)
        {
            _produktDienst = produktDienst;
        }
        [HttpPost, Authorize(Roles ="Admin")]
        public async Task<ActionResult<DienstAntwort<Produkt>>> ErstelleProdukt(Produkt produkt)
        {
            var resultat = await _produktDienst.ErstelleProduktAsync(produkt);
            return Ok(resultat);
        }
        [HttpPut, Authorize(Roles = "Admin")]
        public async Task<ActionResult<DienstAntwort<Produkt>>> AktualisiereProdukt(Produkt produkt)
        {
            var resultat = await _produktDienst.AktualisiereProduktAsync(produkt);
            return Ok(resultat);
        }
        [HttpDelete("{produktID}"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<DienstAntwort<bool>>> LöscheProdukt(int produktID)
        {
            var resultat = await _produktDienst.LöscheProduktAsync(produktID);
            return Ok(resultat);
        }
        [HttpGet("admin"), Authorize(Roles = "Admin")]
        public async Task<ActionResult<DienstAntwort<List<Produkt>>>> GeheZurAdminProdukte()
        {
            var resultat = await _produktDienst.GeheZurAdminProdukteAsync();
            return Ok(resultat);
        }
        [HttpGet]
        public async Task<ActionResult<DienstAntwort<List<Produkt>>>>GeheZurProdukte()
        {
            var resultat = await _produktDienst.GeheZurProdukteAsync();
            return Ok(resultat);
        }
        [HttpGet("{produktID}")]
        public async Task<ActionResult<DienstAntwort<Produkt>>> GeheZumProdukt(int produktID)
        {
            var resultat = await _produktDienst.GeheZumProduktAsync(produktID);
            return Ok(resultat);
        }
        [HttpGet("kategorie/{kategorieUrl}")]
        public async Task<ActionResult<DienstAntwort<List<Produkt>>>> GeheZurProdukteNachKategorie(string kategorieUrl)
        {
            var resultat = await _produktDienst.GeheZurProdukteNachKategorieAsync(kategorieUrl);
            return Ok(resultat);
        }
        [HttpGet("suche/{suchText}/{seite}")]
        public async Task<ActionResult<DienstAntwort<ResultatProduktSuche>>> SucheProdukte(string suchText, int seite=1)
        {
            var resultat = await _produktDienst.SucheProdukteAsync(suchText,seite);
            return Ok(resultat);
        }
        [HttpGet("sucheAnregungen/{suchText}")]
        public async Task<ActionResult<DienstAntwort<List<Produkt>>>> GeheAnregungenZurProduktSuche(string suchText)
        {
            var resultat = await _produktDienst.GeheAnregungenZurProduktSucheAsync(suchText);
            return Ok(resultat);
        }
        [HttpGet("vorgestellt")]
        public async Task<ActionResult<DienstAntwort<List<Produkt>>>> GeheZurVorgestellteProdukte()
        {
            var resultat = await _produktDienst.GeheZurVorgestellteProdukteAsync();
            return Ok(resultat);
        }
    }
}
