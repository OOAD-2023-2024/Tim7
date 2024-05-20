using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car.Models
{
    public class Korisnik: Account
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }
        public String BrojVozacke { get; set; }
        public DateTime DatumIstekVozacke { get; set; }

        public Korisnik() { }
    }
}
