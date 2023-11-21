using System.ComponentModel.DataAnnotations;

namespace KomisSamochodowy.Models
{
    public class Marka
    {
        public int Id { get; set; }
        [Display(Name="Nazwa")]
        public string Nazwa { get; set; }

        public ICollection<Samochod> Samochody { get; } = new List<Samochod>();
    }
}
