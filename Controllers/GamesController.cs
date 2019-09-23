using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using capstonebackend.Models;

namespace capstonebackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]

  public class GamesController : ControllerBase
  {
    [HttpPost]
    // Creates a new game
    public ActionResult<Game> CreateGame([FromBody]Game entry)
    {
      if (entry == null)
      {
        return BadRequest();
      }
      else
      {
        var db = new DatabaseContext();
        db.Games.Add(entry);
        db.SaveChanges();
        return Ok(entry);
      }

    }

    [HttpGet]
    // gets all games
    public ActionResult<IEnumerable<Game>> GetAllGames()
    {
      var db = new DatabaseContext();
      var games = db.Games.OrderByDescending(game => game.DateCreated);
      return games.ToList();
    }

    [HttpGet("{id}")]
    // gets one game
    public ActionResult<Game> GetOneGame(int id)
    {
      var db = new DatabaseContext();
      var games = db.Games.FirstOrDefault(g => g.Id == id);
      if (games == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(games);
      }
    }

    [HttpDelete("{id}")]
    // deletes a game
    public ActionResult DeleteGame(int id)
    {

      var db = new DatabaseContext();
      var games = db.Games.FirstOrDefault(g => g.Id == id);
      if (games == null)
      {
        return NotFound();
      }
      else
      {
        db.Games.Remove(games);
        db.SaveChanges();
        return Ok();
      }

    }

  }
};