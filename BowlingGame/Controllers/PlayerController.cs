using BowlingGame.DAL;
using BowlingGame.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Player : ControllerBase
    {
        private readonly BowlingDbContext _bowlingDbContext;

                public Player(BowlingDbContext bowlingDbContext)
        { 
            _bowlingDbContext = bowlingDbContext;
        }

   
        [HttpGet]
        public PlayerDTO GetPlayer(int playerid)
        {
            return _bowlingDbContext.Players.Include(p => p.ScoreCard).ThenInclude(x => x.Frames).Where(p => p.Id == playerid).FirstOrDefault();
        }

    }
}
