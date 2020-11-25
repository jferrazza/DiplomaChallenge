using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace challenge_api.Models
{
  public class Game
  {
    public int id { get; set; }
    public string detail { get; set; }
    public string venue { get; set; }
    public DateTime date { get; set; }
  }
}
