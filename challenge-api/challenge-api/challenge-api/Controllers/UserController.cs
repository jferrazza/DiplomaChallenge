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
    public class UserController : ApiController
    {
    public HttpResponseMessage Get()
    {
      string query = "select id, name, password, role from dbo.cUsers";

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
    public HttpResponseMessage Get(string name, string password)
    {
      string query = $"select id, name, password, role from dbo.cUsers where name='{name}' and password='{password}'";

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
    public string Post(User user)
    {
      try
      {
        string query = $@"insert into dbo.cUsers(name,password,role) values ('{user.name}','{user.password}','{user.role}')";

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

    public string Put(User user)
    {
      try
      {
        string query = $@"update dbo.cUsers set name='{user.name}', role='{user.role}', password='{user.password}' where id={user.id}";

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
        string query = $@"delete from dbo.cUsers where id={id}";

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
