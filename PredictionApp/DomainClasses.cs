using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredictionApp
{
  public class Country
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class Team
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int CountryId { get; set; }
    public decimal StrengthRating { get; set; }
  }

  public class Match
  {
    //Polja iz tablice Match
    public int Id { get; set; }
    public int HomeTeamId { get; set; }
    public int AwayTeamId { get; set; }
    public DateTime MatchDate { get; set; }
    public decimal ProbHomeWin { get; set; }
    public decimal ProbAwayWin { get; set; }
    public decimal ProbDraw { get; set; }
    //Dodatna polja za prikaz imena timova
    public string HomeTeam { get; set; }
    public string AwayTeam { get; set; }
  }

  public class PredictionType
  {
    public int Id { get; set; }
    public string Name { get; set; }
  }

  public class Prediction
  {
    //Polja iz tablice Prediction
    public int Id { get; set; }
    public int MatchId { get; set; }
    public string UserName { get; set; }
    public int PredictionTypeId { get; set; }
    public DateTime CreatedAt { get; set; }
    //Dodatna polja za prikaz podataka u gridu
    public string Match { get; set; }
    public string PredictionType { get; set; }
  }
}
