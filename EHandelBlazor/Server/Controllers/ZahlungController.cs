namespace EHandelBlazor.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZahlungController : ControllerBase
    {
        private readonly IZahlungDienst _zahlungDienst;

        public ZahlungController(IZahlungDienst zahlungDienst)
        {
            _zahlungDienst = zahlungDienst;
        }
        [HttpPost("kasse"), Authorize]
        public async Task<ActionResult<string>> ErstellenKasseSitzung()
        {
            var sitzung = await _zahlungDienst.ErstellenKasseSitzungAsync();
            return Ok(sitzung.Url);
        }

    }
}
