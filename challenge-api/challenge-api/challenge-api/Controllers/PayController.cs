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
  public class PayController : ApiController
  {
    public HttpResponseMessage Get()
    {
      string query = "select id, playerid, gameid, amount from dbo.cPays";

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

    public string Post(Pays user)
    {
      try
      {
        string query = $@"insert into dbo.Pays(playerid, gameid, amount) values ('{user.playerid}','{user.gameid}','{user.amount}')";

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

    public string Put(Pays user)
    {
      try
      {
        string query = $@"update dbo.Pays set playerid='{user.playerid}', gameid='{user.gameid}', amount='{user.amount}' where id={user.id}";

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
        string query = $@"delete from dbo.cPays where id={id}";

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
