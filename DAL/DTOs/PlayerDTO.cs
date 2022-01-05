
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingGame.DAL.Models
{
    public class PlayerDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Guid { get; set; }
        public string Name { get; set; }   

        public int GameId { get; set; }
        public GameDTO Game { get; set; }

        public ScoreCardDTO ScoreCard { get; set; }

    }
}
