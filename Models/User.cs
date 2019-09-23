using System;

namespace capstonebackend.Models
{
  public class User
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public string EmailAddress { get; set; }
    public string FavoriteGame { get; set; }
    public int ZipCode { get; set; }
    public string ProfilePicUrl { get; set; }
    public int GamesAttended { get; set; } = 0;
    public DateTime DateJoined { get; set; } = DateTime.Now;
  }
}