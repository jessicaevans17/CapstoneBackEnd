using System;

namespace capstonebackend.Models
{

  public class Game
  {
    public int Id { get; set; }
    public string GameTitle { get; set; }
    public DateTime DateCreated { get; set; } = DateTime.Now;
    public int ZipCode { get; set; }
    public string Address { get; set; }
    public int MinPlayers { get; set; }
    public int MaxPlayers { get; set; }
    public string Creator { get; set; }
    public DateTime DateOfPlay { get; set; }


  }
}