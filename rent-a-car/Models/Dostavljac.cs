namespace rent_a_car.Models
{
    public class Dostavljac : Account
    {
        public DateTime DatumZaposlenja { get; set; }
        public StatusVozaca Status { get; set; }

        public Dostavljac() { }

    }
}
