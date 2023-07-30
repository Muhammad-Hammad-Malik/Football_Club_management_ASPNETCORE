using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class injuryupdateModel : PageModel
    {
        public injuryedit info = new injuryedit();
        public string errormessage = "";
        public string smessage = "";

        public void OnGet()
        {
            string incid = Request.Query["incid"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM injury where incid=@incid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("incid", incid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.itype = reader.GetString(2);
                                info.duration = "" + reader.GetInt32(3);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }
        }
        public void OnPost()
        {
            info.itype = Request.Form["itype"];
            info.duration = Request.Form["duration"];
            if (info.itype.Length == 0 || info.duration.Length == 0)
            {
                errormessage = "ALL FIELDS MUST BE FILLED";
                return;
            }

            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE injury " + "SET type=@itype, duration=@duration " +
                                 "WHERE incid=@incid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@incid", Request.Query["incid"].ToString());
                        command.Parameters.AddWithValue("@pid", info.pid);
                        command.Parameters.AddWithValue("@itype", info.itype);
                        command.Parameters.AddWithValue("@duration", info.duration);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }
        }
    }
    public class injuryedit
    {
        public string incid = "";
        public string pid = "";
        public string itype = "";
        public string duration = "";
    }
}

