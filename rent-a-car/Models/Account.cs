using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public String BrojTelefona { get; set; }
        public String Email { get; set; }
        public String Drzava { get; set; }
        public String Adresa { get; set; }
        public String KorisnickoIme { get; set; }
        public String Sifra { get; set; }
        public Role Role { get; set; }  

        public Account () { }
    }
}
