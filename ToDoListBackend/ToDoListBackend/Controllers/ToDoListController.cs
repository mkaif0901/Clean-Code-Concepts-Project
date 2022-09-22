using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ToDoListBackend.Controllers
{
    public class ToDoListController : ApiController
    {

        // GET api/<controller>
        public HttpResponseMessage Get()
        {
            string temp = "title";
            string orderBy = " order by " + temp;
            
            string query = @"select * from Tavisca.ToDoList";
            if (temp != null && temp != "")
            {
                query += orderBy;
            }
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        // GET api/<controller>/5
        public HttpResponseMessage Get(int id)
        {
            string query = @"select * from Tavisca.ToDoList
                            where id=" + id + @"";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["ToDoListDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        // POST api/<controller>
        public HttpResponseMessage Post(Models.ToDoItem toDoList)
        {
            try
            {
                string query = @"insert into Tavisca.ToDoList values('" + toDoList.title + @"' ,'" + toDoList.description + @"'
                ,'" + toDoList.status + @"'
                )
                ";

                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ToDoListDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return Get();
            }
            catch (Exception)
            {
                return Get();
            }

        }

        // PUT api/<controller>/5
        public string Put(Models.ToDoItem toDoList, int id)
        {
            try
            {
                string query = @"update Tavisca.ToDoList set 
                Title='" + toDoList.title + @"',
                Description='" + toDoList.description + @"',
                Status='" + toDoList.status + @"'
                where id=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ToDoListDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Successfully Updated";
            }
            catch (Exception)
            {
                return "Put Failed";
            }

        }

        public string delete(int id)
        {
            try
            {
                string query = @"
                delete from Tavisca.ToDoList
                where id=" + id + @"";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.
                    ConnectionStrings["ToDoListDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }
                return "Successfully Deleted";
            }
            catch (Exception)
            {
                return "Delete Failed";
            }

        }
    }
}