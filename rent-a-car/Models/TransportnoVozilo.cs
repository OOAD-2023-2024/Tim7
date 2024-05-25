using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car.Models
{
    public class TransportnoVozilo : Vozilo
    {
       
        public TransportniTip? Tip { get; set; }
        public double? Nosivost { get; set; }
        public double? Duzina { get; set; }
        public bool? Prikolica { get; set; }
        
        public TransportnoVozilo() { }
    }
}
