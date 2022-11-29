namespace EHandelBlazor.Server.Dienste.ZahlungDienst
{
    public class ZahlungDienst : IZahlungDienst
    {
        private readonly IWarenKorbDienst _warenKorbDienst;
        private readonly IAuthDienst _authDienst;
        private readonly IBestellungDienst _bestellungDienst;

        public ZahlungDienst(IWarenKorbDienst warenKorbDienst, IAuthDienst authDienst,
            IBestellungDienst bestellungDienst)
        {
            StripeConfiguration.ApiKey = "sk_test_51M91ieH1fm9paOYoW6Sf2otu8FE7C0TZXbO1uD8QVTP0w5WL8v2x9ikOHHO3pg6JKEmYH28FyVwa6LIifdAhAnts00hZ6Hb0V2";

            _warenKorbDienst = warenKorbDienst;
            _authDienst = authDienst;
            _bestellungDienst = bestellungDienst;
        }
        public async Task<Session> ErstellenKasseSitzungAsync()
        {
            var produkte = (await _warenKorbDienst.GeheZurDbWarenKorbProdukteAsync()).Daten;
            var linieArktikel = new List<SessionLineItemOptions>();
            produkte.ForEach(produkt => linieArktikel.Add(new SessionLineItemOptions
            {
                PriceData = new SessionLineItemPriceDataOptions
                {
                    UnitAmountDecimal = produkt.Preis * 100,
                    Currency = "eur",
                    ProductData = new SessionLineItemPriceDataProductDataOptions
                    {
                        Name = produkt.Title,
                        Images = new List<string>
                        {
                            produkt.BildUrl
                        }
                    }
                },
                Quantity = produkt.Menge
            }));

            var options = new SessionCreateOptions
            {
                CustomerEmail = _authDienst.GeheZurBenutzerEmail(),
                PaymentMethodTypes = new List<string>
                {
                    "card"
                },
                LineItems = linieArktikel,
                Mode = "payment",
                SuccessUrl = "https://localhost:7260/bestellung-erfolgreich",
                CancelUrl = "https://localhost:7260/warenkorb"
            };
            var dienst = new SessionService();
            Session sitzung = dienst.Create(options);
            return sitzung;
        }
    }
}
