
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BowlingGame.DAL.Models
{
    public class FrameDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string? Shot1 { get; set; }
        public string? Shot2 { get; set; }
        public string? Shot3 { get; set; }
        public int FrameNumber { get; set; }

        public int ScoreCardId { get; set; }
        [JsonIgnore]
        public virtual ScoreCardDTO ScoreCard { get; set; }
    }
}

