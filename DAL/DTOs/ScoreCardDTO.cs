
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BowlingGame.DAL.Models
{
    
    public class ScoreCardDTO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public ICollection<FrameDTO>? Frames { get; set; }
        public int PlayerId { get; set; }
        [JsonIgnore]
        public PlayerDTO Player { get; set; }


        public int Score { get
            {
                var shotList = ShotList();
                if(shotList == null) return 0;
                int score = 0;
                for (int i = 0; i < shotList.Count; i++)
                {
                    var currentShot = shotList[i];
                    if(currentShot == "x")
                    {
                        score += 10;

                        //If this was the last shot in the list we can't calculate to total score so add 10 and return 
                        if (i == shotList.Count-1) return score;
                        
                        var nextShot = shotList[i + 1];
                        //If the strike was the second last shot add 10 plust the next shot
                        
                        if (i == shotList.Count - 2)
                        {
                            score += nextShot == "x" ? 10 : int.Parse(nextShot);
                            continue;
                        }

                        var nextNextShot = shotList[i + 2];

                        //If the next shot is a strike and 10, then if the shot afterw is also a strike add another 10 then continue, otherwise....
                        if (nextShot == "x") { 
                            score += 10;
                            score += nextNextShot == "x" ? 10 : int.Parse(nextNextShot);
                            continue;
                        }
                        if (nextNextShot == "x") {
                            score += 10;
                            continue;
                        }
                        //... check if the second shot is a / (a strike cant be followed by a spare) and add 10 then continue....
                        if (nextNextShot == "/") { score += 10; continue; }

                        //...other wise add teh open frame scores
                        score += int.Parse(nextShot) + int.Parse(nextNextShot);
                        //if the 19th shot is a strike return as the score will have counted
                        if (i == shotList.Count - 3) break;
                        continue;
                    }
                    if(currentShot == "/")
                    {
                        //Remove the previous shot as the spar makes the whole frame worth 10
                        score -= int.Parse(shotList[i - 1]);
                        score += 10;
                        //If this was the last shot in the list we can't calculate to total score so add 10 and return 
                        if (i == shotList.Count - 1) return score;
                        
                        var nextShot = shotList[i + 1];
                        //Add 10 and the next shot
                        score += nextShot == "x" || nextShot == "/" ? 10 : int.Parse(nextShot);

                        //if this was the second last return the score
                        if (i == shotList.Count -2) break; 
                    }
                    else
                    {
                        score += int.Parse(currentShot);
                    }
                }
                return score;
            }
        }
        
        
        private List<string?>? ShotList()
        {
            if( Frames == null )return null;

            var shotList = new List<string?>();
            foreach(var frame in Frames.OrderBy(x => x.FrameNumber))
            {
                shotList.Add(frame.Shot1);
                shotList.Add(frame.Shot2);
                shotList.Add(frame.Shot3);
            }

            return shotList.Where(x => x != null).ToList();
        }
    }
}
