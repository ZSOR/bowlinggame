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
        public FrameDTO AddFrame(int scoreCardId, string shot1, string shot2)
        {
            var scoreCard = _bowlingDbContext.ScoreCards.Include(y => y.Frames).Where(x => x.Id == scoreCardId).FirstOrDefault();

            if (scoreCard == null)  throw new BadHttpRequestException($"No scored cared with id {scoreCardId}");  

            if (scoreCard.Frames != null && scoreCard.Frames.Count == 10) throw new BadHttpRequestException("All frames recorded");

            var frameNumber = scoreCard.Frames == null ? 0: scoreCard.Frames.Count + 1;

            var frame = _bowlingDbContext.Add(new FrameDTO
            {
                ScoreCardId = scoreCardId,
                Shot1 = shot1,
                Shot2 = shot2,
                FrameNumber = frameNumber,
                ScoreCard = scoreCard
            });

            _bowlingDbContext.SaveChanges();

            return frame.Entity;
        }
    }
}
