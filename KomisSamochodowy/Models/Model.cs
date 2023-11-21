namespace KomisSamochodowy.Models
{
    public class Model
    {

        public int Id { get; set; }
        public string Nazwa { get; set; }

        public ICollection<Samochod> Samochody { get; } = new List<Samochod>();
    }
}
