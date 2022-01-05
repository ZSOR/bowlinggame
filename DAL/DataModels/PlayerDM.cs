
namespace BowlingGame.DAL.Models
{
    public class PlayerDM 
    {
        public Guid Guid { get; set; }
        public string Name { get; set; }   

        public ScoreCardDM ScoreCard { get; set; }

    }
}
