namespace EHandelBlazor.Server.Dienste.ZahlungDienst
{
    public interface IZahlungDienst
    {
        Task<Session> ErstellenKasseSitzungAsync();
    }
}
