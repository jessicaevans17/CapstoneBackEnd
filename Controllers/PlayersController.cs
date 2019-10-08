using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using capstonebackend;
using CapstoneBackEnd.Models;
using Microsoft.AspNetCore.Mvc;

namespace CapstoneBackEnd.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class PlayersController : ControllerBase
  {
    private DatabaseContext context;

    public PlayersController(DatabaseContext _context)
    {
      this.context = _context;
    }
    [HttpPost("{gameId}")]

    public ActionResult<Player> AddPlayer(int gameId, [FromBody]Player entry)
    {
      var games = context.Games.FirstOrDefault(g => g.Id == gameId);
      if (games == null)
      {
        return NotFound();
      }
      else
      {
        entry.GameId = gameId;
        context.Players.Add(entry);
        context.SaveChanges();
        return Ok(entry);
      }

    }

    [HttpGet("{gameId}")]

    public ActionResult<IEnumerable<Player>> GetPlayersPerGame(int gameId)
    {
      var games = context.Games.FirstOrDefault(g => g.Id == gameId);
      var players = context.Players.Where(p => p.GameId == gameId);
      if (games == null)
      {
        return NotFound();
      }
      else
      {
        return players.ToList();

      }
    }
    [HttpDelete("{gameId}/{playerId}")]

    public ActionResult DeletePlayer(int gameId, string playerId)
    {
      var game = context.Games.FirstOrDefault(g => g.Id == gameId);
      var player = context.Players.Where(p => p.GameId == gameId).FirstOrDefault(p => p.UserId == playerId);

      if (game == null || player == null)
      {
        return NotFound();
      }
      else
      {
        context.Players.Remove(player);
        context.SaveChanges();
        return Ok();
      }

    }

    [HttpGet]
    public ActionResult<IEnumerable<Player>> ShowAllPlayers()
    {
      var players = context.Players.OrderByDescending(player => player.Id);
      return players.ToList();
    }
  }
}