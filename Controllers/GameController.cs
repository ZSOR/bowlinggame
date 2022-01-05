using BowlingGame.DAL;
using BowlingGame.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BowlingGame.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly BowlingDbContext _bowlingDbContext;

        public GameController(BowlingDbContext bowlingDbContext)
        {
            var factory = new ApplicationDbContextFactory();
            _bowlingDbContext = bowlingDbContext;
        }

        [HttpPost]
        public GameDTO Create([FromBody]string[] playerNames)
        {
            if (playerNames.Length== 0) throw new BadHttpRequestException("Please provide player names (1 or 2)");
            if (playerNames.Length > 2) throw new BadHttpRequestException("This game handles a maximum of two players");


            var players = playerNames.Select(x => new PlayerDTO()
            {
                Name = x,
                ScoreCard = new ScoreCardDTO()
            });
            var game = _bowlingDbContext.Add(new GameDTO()
            {
                Players = players.ToArray()
            });

            try
            {
                _bowlingDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return game.Entity;
        }

        [HttpGet]
        public GameDTO Get(int id)
        {
            return _bowlingDbContext.Games
                .Include(x => x.Players)
                .Where(g => g.ID == id)
                .FirstOrDefault();
        }

    }
}
