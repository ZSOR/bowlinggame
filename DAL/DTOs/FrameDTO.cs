
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace BowlingGame.DAL.Models
{
    public class FrameDTO
    {
        private char?[] ValidScores = { 'x', '/', '1', '2', '3', '4', '5', '6', '7', '9' };


        public FrameDTO() { }

        public FrameDTO(char? shot1, char? shot2, char? shot3, int frameNumber)
        {
            if(shot1 == null || !ValidScores.Contains(shot1) ) throw new ArgumentException("A first shot is required for this frame");
            if(shot1 != 'x' && shot2 == null) throw new ArgumentNullException("A second score is required");
            if (shot3 != null && frameNumber != 10) throw new ArgumentException("A thrid shot can only be supplied if it is the final frame");
            if ((shot3 != null && shot1 != 'x') || (shot3 != null && shot2 != '/')) throw new ArgumentException("A third shot can only be submitted if a shot on frame 10 was a strige or spare ");

            Shot1 = shot1;
            Shot2 = shot2;
            Shot3 = shot3;  
            FrameNumber = frameNumber;  
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public char? Shot1 { get; set; }
        public char? Shot2 { get; set; }
        public char? Shot3 { get; set; }
        public int FrameNumber { get; set; }

        public int ScoreCardId { get; set; }
        [JsonIgnore]
        public virtual ScoreCardDTO ScoreCard { get; set; }
    }
}

