using System.ComponentModel.DataAnnotations;

namespace VizvezetekWebAPI.Models
{
    public class Hely
    {
        [Key]
        public int Az { get; set; }
        public string Telepules { get; set; }
        public string Utca { get; set; }
        public ICollection<Munkalap> Munkalapok { get; set; }
    }
}
