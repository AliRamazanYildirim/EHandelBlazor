﻿namespace EHandelBlazor.Server.Controllers
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
            var resultat = await _warenKorbDienst.WarenKorbArtikelSpeichernAsync(warenKorbArtikel);
            return Ok(resultat);
        }

        [HttpPost("addieren")]
        public async Task<ActionResult<DienstAntwort<bool>>> InWarenKorbLegen(WarenKorbArtikel warenKorbArtikel)
        {
            var resultat = await _warenKorbDienst.InWarenKorbLegenAsync(warenKorbArtikel);
            return Ok(resultat);
        }

        [HttpPut("menge-aktualisieren")]
        public async Task<ActionResult<DienstAntwort<bool>>> MengeAktualisieren(WarenKorbArtikel warenKorbArtikel)
        {
            var resultat = await _warenKorbDienst.MengeAktualisierenAsync(warenKorbArtikel);
            return Ok(resultat);
        }

        [HttpDelete("{produktID}/{produktArtID}")]
        public async Task<ActionResult<DienstAntwort<bool>>> ProduktAusWarenKorbEntfernen(int produktID, int produktArtID)
        {
            var resultat = await _warenKorbDienst.ArtikelAusWarenKorbEntfernenAsync(produktID, produktArtID);
            return Ok(resultat);
        }

        [HttpGet("anzahl")]
        public async Task<ActionResult<DienstAntwort<int>>> GeheZurWarenKorbArtikelAnzahl()
        {
            return await _warenKorbDienst.GeheZurWarenKorbArtikelAnzahlAsync();
        }

        [HttpGet]
        public async Task<ActionResult<DienstAntwort<List<AntwortDesWarenKorbProduktes>>>> GeheZurDbWarenKorbProdukte()
        {
            var resultat = await _warenKorbDienst.GeheZurDbWarenKorbProdukteAsync();
            return Ok(resultat);
        }


    }
}
