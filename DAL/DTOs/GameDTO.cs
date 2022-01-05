
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BowlingGame.DAL.Models
{
    public class GameDTO 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public virtual IEnumerable<PlayerDTO> Players { get; set; }

    }
}
