using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace rent_a_car.Models
{
    public class VoziloViewModel
    {
        [Required]
        public string Proizvodjac { get; set; }
        public string Model { get; set; }
        public double Cijena { get; set; }
        public string Slika { get; set; }
        public string Opis { get; set; }
        public TipVozila Tip { get; set; }
        public string RegistarskeTablice { get; set; }
        public bool Navigacija { get; set; }
        public Transmisija Transmisija { get; set; }
        public VrstaGoriva Gorivo { get; set; }
        public Poslovnica MaticnaPoslovnicaId { get; set; }

        // TransportnoVozilo properties
        public TransportniTip? TransportnoVozilo_Tip { get; set; }
        public double? Nosivost { get; set; }
        public double? Duzina { get; set; }
        public bool? Prikolica { get; set; }

        // PutnickoVozilo properties
        public int? BrojSjedista { get; set; }
        public bool? Tempomat { get; set; }

     public VoziloViewModel() { }
    }
}
