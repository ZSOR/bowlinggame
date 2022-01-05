
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
                    if(currentShot == 'x')
                    {
                        HandleStrike(shotList, i, ref score);
                        if (i == shotList.Count - 3) break;
                        
                    }
                    else if(currentShot == '/')
                    {
                        HandleSpare(shotList, i, ref score);
                        //if this was the second last return the score
                        if (i == shotList.Count -2) break; 
                    }
                    else
                    {
                        score += (int)char.GetNumericValue(currentShot);
                    }
                }
                return score;
            }
        }
        

        private static void HandleSpare(List<char> shotList, int currentShot, ref int score)
        {
            //Remove the previous shot as the spar makes the whole frame worth 10
            score -= (int)char.GetNumericValue(shotList[currentShot - 1]);
            score += 10;
            //If this was the last shot in the list we can't calculate to total score so add 10 and return 
            if (currentShot == shotList.Count - 1) return;

            var nextShot = shotList[currentShot + 1];
            //Add 10 and the next shot
            score += nextShot == 'x' || nextShot =='/' ? 10 : (int)char.GetNumericValue(nextShot);
        }

        private static void HandleStrike(List<char> shotList, int currentShot, ref int score)
        {
            score += 10;

            //If this was the last shot in the list we can't calculate to total score so add 10 and return 
            if (currentShot == shotList.Count - 1) return;

            var nextShot = shotList[currentShot + 1];
            //If the strike was the second last shot add 10 plust the next shot

            if (currentShot == shotList.Count - 2)
            {
                score += nextShot == 'x' ? 10 : (int)char.GetNumericValue(nextShot);
                return;
            }

            var nextNextShot = shotList[currentShot + 2];

            //If the next shot is a strike and 10, then if the shot afterw is also a strike add another 10 then continue, otherwise....
            if (nextShot == 'x')
            {
                score += 10;
                score += nextNextShot == 'x' ? 10 : (int)char.GetNumericValue(nextNextShot);
                return;
            }
            if (nextNextShot == 'x')
            {
                score += 10;
                return;
            }
            //... check if the second shot is a / (a strike cant be followed by a spare) and add 10 then continue....
            if (nextNextShot == '/') { score += 10; return; }

            //...other wise add teh open frame scores
            score += (int)char.GetNumericValue(nextShot) + (int)char.GetNumericValue(nextNextShot);
            //if the 19th shot is a strike return as the score will have counted

            return;
        }

        
        private List<char>? ShotList()
        {
            if( Frames == null )return null;

            var shotList = new List<char>();
            foreach(var frame in Frames.OrderBy(x => x.FrameNumber))
            {
                if(frame.Shot1 != null)
                {
                    shotList.Add((char)frame.Shot1);
                }
                if(frame.Shot2 != null)
                {
                    shotList.Add((char)frame.Shot2);
                }
                if(frame.Shot3 != null)
                {
                    shotList.Add((char)frame.Shot3);
                }
                
            }

            return shotList;
        }
    }
}
