using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Data.SqlTypes;
using System.Drawing;

namespace KomisSamochodowy.Models
{
    public class Samochod
    {

        public int Id { get; set; }
        public string Kolor { get; set; }

        public float PojemnoscSilnika { get; set; }

        public float Przebieg { get; set; }

        public string NumerVin { get; set; }

        public float Cena { get; set; }

        public int MarkaId { get; set; }
        public Marka? Marka { get; set; } = null!;

        public int ModelId { get; set; }
        public Model? Model { get; set; } = null!;

        public int NadwozieId { get; set; }
        public Nadwozie? Nadwozie { get; set; } = null!;

        public int PaliwoId { get; set; }
        public Paliwo? Paliwo { get; set; } = null!;
    }
}