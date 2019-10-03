using System.Collections.Generic;
using capstonebackend.Models;

namespace CapstoneBackEnd.Models
{
  public class Player
  {
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string ProfileURL { get; set; }
    public int GameId { get; set; }
    public Game Game { get; set; }
  }
}