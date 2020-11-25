using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge_api.Models
{
  public class Pays
  {
    public int id { get; set; }
    public int playerid { get; set; }
    public int gameid { get; set; }
    public double amount { get; set; }
  }
}
