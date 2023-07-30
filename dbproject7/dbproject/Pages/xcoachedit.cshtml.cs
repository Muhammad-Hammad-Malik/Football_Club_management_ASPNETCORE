using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class xcoacheditModel : PageModel
    {
        public coachshow info = new coachshow();
        public string errormessage = "";
        public string smessage = "";

        public void OnGet()
        {
            string cid = Request.Query["cid"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM coaches where cid=@cid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cid", cid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.cid = "" + reader.GetInt32(0);
                                info.fn = reader.GetString(1);
                                info.ln = reader.GetString(2);
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
            info.fn = Request.Form["fn"];
            info.ln = Request.Form["ln"];
            if (info.fn.Length == 0 || info.ln.Length == 0)
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
                    string sql = "UPDATE coaches " + "SET fname=@fname, lname=@lname " +
                                 "WHERE cid=@cid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@cid", Request.Query["cid"].ToString());
                        command.Parameters.AddWithValue("@fname", info.fn);
                        command.Parameters.AddWithValue("@lname", info.ln);
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
}
