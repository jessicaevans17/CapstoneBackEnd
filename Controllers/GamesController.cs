using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using capstonebackend.Models;
using Microsoft.AspNetCore.Authorization;
using CapstoneBackEnd.Models;
using Microsoft.EntityFrameworkCore;

namespace capstonebackend.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class GamesController : ControllerBase
  {
    private DatabaseContext context;

    public GamesController(DatabaseContext _context)
    {
      this.context = _context;
    }
    [HttpPost]
    // Creates a new game
    public ActionResult<Game> CreateGame([FromBody]Game entry)
    {

      var firstName = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname").Value;
      var lastName = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/surname").Value;
      var userId = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;
      var name = User.Claims.First(f => f.Type == "name").Value;
      var picture = User.Claims.First(f => f.Type == "picture").Value;
      var nickname = User.Claims.First(f => f.Type == "nickname").Value;
      var email = User.Claims.First(f => f.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Value;

      if (entry == null)
      {
        return BadRequest();
      }
      else
      {

        // create the player
        context.Games.Add(entry);
        // create a new player
        var player = new Player { UserId = userId, Name = name, Email = email, ProfileURL = picture, GameId = entry.Id, FirstName = firstName, LastName = lastName };

        // add that player our database
        context.Players.Add(player);
        context.SaveChanges();
        return Ok(entry);
      }

    }

    [HttpGet]
    // gets all games
    public ActionResult<IEnumerable<Game>> GetAllGames()
    {

      var games = context.Games.Include(g => g.Players).OrderBy(game => game.DateOfPlay);
      return games.ToList();
    }

    [HttpGet("{id}")]
    // gets one game
    public ActionResult<Game> GetOneGame(int id)
    {

      var games = context.Games.Include(g => g.Players).FirstOrDefault(g => g.Id == id);
      if (games == null)
      {
        return NotFound();
      }
      else
      {
        return Ok(games);
      }
    }

    [HttpDelete("delete/{gameId}/{creatorId}")]
    // deletes a game
    public ActionResult DeleteGame(int gameId, string creatorId)
    {


      var games = context.Games.Where(p => p.CreatorId == creatorId).FirstOrDefault(p => p.Id == gameId);


      if (games == null)
      {
        return NotFound();
      }
      else
      {
        context.Games.Remove(games);
        context.SaveChanges();
        return Ok();
      }

    }

    // get games hosted by one player
    [HttpGet("hosting/{creatorId}")]

    public ActionResult<IEnumerable<Game>> GetHostedGames(string creatorId)
    {
      var games = context.Games.Include(g => g.Players).Where(g => g.CreatorId == creatorId);

      if (games == null)
      {
        return NotFound();
      }
      else
      {
        return games.ToList();
      }
    }


  }
};