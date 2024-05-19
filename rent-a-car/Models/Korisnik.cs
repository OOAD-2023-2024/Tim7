namespace rent_a_car.Models
{
    public class Korisnik: Account
    {
        public String BrojVozacke { get; set; }
        public DateTime DatumIstekVozacke { get; set; }

        public Korisnik() { }
    }
}
