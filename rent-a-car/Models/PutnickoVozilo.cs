using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car.Models
{
    public class PutnickoVozilo: Vozilo
    {
        public PutnickiTip Tip { get; set; }
        public int BrojSjedista { get; set; }
        public bool Tempomat { get; set; }

        public PutnickoVozilo() { }
    }
}
