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
  public class FutureController : ApiController
  {
    public HttpResponseMessage Get()
    {
      string query = "select id, detail, venue, date from dbo.cGame where date>GETDATE()";

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
