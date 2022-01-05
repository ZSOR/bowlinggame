
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BowlingGame.DAL.Models
{
    public class PlayerDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }   

        public int GameId { get; set; }
        [JsonIgnore]
        public GameDTO Game { get; set; }

        public ScoreCardDTO ScoreCard { get; set; }

    }
}
