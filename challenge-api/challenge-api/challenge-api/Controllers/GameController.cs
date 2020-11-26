using challenge_api.Models;
using System;
using System.Collections.Generic;
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
  public class GameController : ApiController
  {
    public HttpResponseMessage Get()
    {
      string query = "select id, detail, venue, date from dbo.cGame";

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

    public string Post(Game user)
    {
      try
      {
        string query = $@"insert into dbo.cGame(detail,venue,date,time) values ('{user.detail}','{user.venue}','{user.date}','{user.time}')";

        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChallengeDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);
        }

        return "Added Successfully";
      }
      catch (Exception ex)
      {
        return "Failed - " + ex.ToString();
      }
    }

    public string Put(Game user)
    {
      try
      {
        string query = $@"update dbo.cGame set date='{user.date}', detail='{user.detail}', venue='{user.venue}' where id={user.id}";

        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChallengeDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);
        }

        return "Updated Successfully";
      }
      catch (Exception ex)
      {
        return "Failed " + ex.ToString();
      }
    }
    public string Delete(int id)
    {
      try
      {
        string query = $@"delete from dbo.cGame where id={id}";

        DataTable table = new DataTable();
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ChallengeDB"].ConnectionString))
        using (var cmd = new SqlCommand(query, con))
        using (var da = new SqlDataAdapter(cmd))
        {
          cmd.CommandType = CommandType.Text;
          da.Fill(table);
        }

        return "Deleted Successfully";
      }
      catch (Exception ex)
      {
        return "Failed " + ex.ToString();
      }
    }
  }
}
