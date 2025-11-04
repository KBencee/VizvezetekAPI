using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace VizvezetekWebAPI.Models
{
    public class Munkalap
    {
        [Key]
        public int Az { get; set; }
        public DateOnly BeDatum { get; set; }
        public DateOnly JavDatum { get; set; }
        public int HelyAz { get; set; }
        public int SzereloAz { get; set; }
        public int MunkaOra { get; set; }
        public int AnyagAr { get; set; }

        [ForeignKey(nameof(HelyAz))]
        [JsonIgnore]
        public Hely? Hely { get; set; }

        [ForeignKey(nameof(SzereloAz))]
        [JsonIgnore]
        public Szerelo? Szerelo { get; set; }
    }
}
