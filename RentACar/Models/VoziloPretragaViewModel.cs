namespace RentACar.Models
{
    public class VoziloPretragaViewModel
    {
        public string SearchTerm { get; set; }
        public double? MinCijena { get; set; }
        public double? MaxCijena { get; set; }
        public string Model { get; set; }
        public TipVozila Tip { get; set; } // Passenger or Commercial
        public List<Vozilo> Cars { get; set; } = new List<Vozilo>();
    }
}

