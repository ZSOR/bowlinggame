
namespace BowlingGame.DAL.Models
{
    public class GameDM 
    {

        public Guid Guid { get; set; }
        public IEnumerable<PlayerDM> Players { get; set; }

    }
}
