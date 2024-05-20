using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace rent_a_car.Models
{
    public class Dostavljac : Account
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Account")]
        public int AccountId { get; set; }

        public DateTime DatumZaposlenja { get; set; }
        public StatusVozaca Status { get; set; }

        public Dostavljac() { }

    }
}
