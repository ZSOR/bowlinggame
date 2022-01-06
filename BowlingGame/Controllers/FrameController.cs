using BowlingGame.DAL;
using BowlingGame.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FrameController : ControllerBase
    {

        private readonly BowlingDbContext _bowlingDbContext;

        public FrameController(BowlingDbContext bowlingDbContext)
        {
            _bowlingDbContext = bowlingDbContext;
        }

        [HttpPost]
        public FrameDTO AddFrame(int playerId, char? shot1, char? shot2, char? shot3)
        {
            var scoreCard = _bowlingDbContext.ScoreCards.Include(y => y.Frames).Where(x => x.PlayerId == playerId).FirstOrDefault();

            if (scoreCard == null)  throw new BadHttpRequestException($"No scored cared with id {playerId}");  

            if (scoreCard.Frames != null && scoreCard.Frames.Count == 10) throw new BadHttpRequestException("All frames recorded");

            var frameNumber = scoreCard.Frames == null ? 0: scoreCard.Frames.Count + 1;
            try
            {
                var frame = _bowlingDbContext.Add(new FrameDTO(shot1, shot2, shot3, frameNumber)
                {
                    ScoreCardId = scoreCard.Id,
                    ScoreCard = scoreCard
                });
                _bowlingDbContext.SaveChanges();

                return frame.Entity;
            } catch (ArgumentException ex)
            {
                throw new BadHttpRequestException(ex.Message);
            }

            
        }
    }
}
