using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace challenge_api.Controllers
{
  public class PayeeController : ApiController
  {
    public HttpResponseMessage Get(bool byusers=false)
    {
      if (byusers)
      {
        string query = @"select cUsers.name, sum(cPays.amount) as amount 
          from cUsers full outer join cPays on cPays.userid = cUsers.id
          group by cUsers.name";

        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChallengeDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);
        }

        return Request.CreateResponse(HttpStatusCode.OK, table);
      }
      else
      {
        string query = "select cGame.detail, cGame.venue, cGame.date, cUsers.name, cPays.amount" +
        " from cGame inner join cPays on cPays.gameid=cGame.id inner join cUsers on cUsers.id=cPays.userid";

        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChallengeDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);
        }

        return Request.CreateResponse(HttpStatusCode.OK, table);
      }
    }
  }
}
