using System.ComponentModel.DataAnnotations;

namespace rent_a_car.Models
{
    public class Poslovnica
    {
        [Key]
        public int Id { get; set; }
        public String Adresa { get; set; }
        public String Kontakt { get; set; }
        public String RadnoVrijeme { get; set; }

        public Poslovnica() { }
    }
}
