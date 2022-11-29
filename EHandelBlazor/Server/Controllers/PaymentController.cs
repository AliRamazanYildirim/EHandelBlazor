namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IZahlungDienst _zahlungDienst;

        public PaymentController(IZahlungDienst zahlungDienst)
        {
            _zahlungDienst = zahlungDienst;
        }
        [HttpPost("kasse"), Authorize]
        public async Task<ActionResult<string>> ErstellenKasseSitzung()
        {
            var sitzung = await _zahlungDienst.ErstellenKasseSitzungAsync();
            return Ok(sitzung.Url);
        }
        [HttpPost]
        public async Task<ActionResult<DienstAntwort<bool>>> BestellungenCheckoutAbwickeln()
        {
            var antwort = await _zahlungDienst.BestellungenCheckoutAbwickelnAsync(Request);
            if (!antwort.Erfolg)
                return BadRequest(antwort.Nachricht);
            return Ok(antwort);
        }
    }
}
