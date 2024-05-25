using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car.Models
{
    public class Vozilo
    {
        [Key]
        public int Id { get; set; }
        public String Proizvodjac {  get; set; }
        public String Model { get; set; }
        public double Cijena { get; set; }
        public String Slika { get; set; }
        public String Opis { get; set; }
        public TipVozila Tip { get; set; }
        public String RegistarskeTablice { get; set; }
        public bool Navigacija { get; set; }
        public Transmisija Transmisija { get; set; }

        public VrstaGoriva Gorivo { get; set; }

        [ForeignKey("Poslovnica")]
        public Poslovnica MaticnaPoslovnicaId { get; set; }



        public Vozilo() { }
    }
}
