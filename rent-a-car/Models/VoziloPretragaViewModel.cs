namespace rent_a_car.Models
{
    public class VoziloPretragaViewModel
    {
        public string SearchTerm { get; set; }
        public double? MinCijena { get; set; }
        public double? MaxCijena { get; set; }
        public string Model { get; set; }
        public string Tip { get; set; } // Passenger or Commercial
        public List<Vozilo> Cars { get; set; } = new List<Vozilo>();
    }
}
