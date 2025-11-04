using System.ComponentModel.DataAnnotations;

namespace VizvezetekWebAPI.Models
{
    public class Szerelo
    {
        [Key]
        public int Az { get; set; }
        public string Nev { get; set; }
        public int KezdEv { get; set; }
        public ICollection<Munkalap> Munkalapok { get; set; }
    }
}
