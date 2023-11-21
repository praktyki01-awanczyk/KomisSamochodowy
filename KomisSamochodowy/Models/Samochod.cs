using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;
using System.Drawing;

namespace KomisSamochodowy.Models
{
    public class Samochod
    {

        public int Id { get; set; }
        [Display(Name = "Kolor")]
        public string Kolor { get; set; }
        [Display(Name = "Pojemność silnika")]

        public float PojemnoscSilnika { get; set; }
        [Display(Name = "Przebieg")]

        public float Przebieg { get; set; }
        [Display(Name = "Numer VIN")]

        public string NumerVin { get; set; }
        [Display(Name = "Cena")]

        public float Cena { get; set; }
        [Display(Name = "Marka")]

        public int MarkaId { get; set; }
        [Display(Name = "Marka")]
        public Marka? Marka { get; set; } = null!;
        [Display(Name = "Model")]
        public int ModelId { get; set; }
        [Display(Name = "Model")]
        public Model? Model { get; set; } = null!;
        [Display(Name = "Nadwozie")]
        public int NadwozieId { get; set; }
        [Display(Name = "Nadwozie")]
        public Nadwozie? Nadwozie { get; set; } = null!;
        [Display(Name = "Paliwo")]
        public int PaliwoId { get; set; }
        [Display(Name = "Paliwo")]
        public Paliwo? Paliwo { get; set; } = null!;
    }
}