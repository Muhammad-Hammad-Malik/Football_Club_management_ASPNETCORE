using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class scheduleupdateModel : PageModel
    {
        public sshow info = new sshow();
        public string errormessage = "";
        public string smessage = "";

        public void OnGet()
        {
            string m = Request.Query["m"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM schedule where matchday=@m";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@m", m);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.m = "" + reader.GetInt32(0);
                                info.r = reader.GetString(1);
                                info.o = reader.GetString(2);
                                info.s = reader.GetString(3);
                                info.d = reader.GetString(4);
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
            info.r = Request.Form["r"];
            info.o = Request.Form["o"];
            info.s = Request.Form["s"];
            info.d= Request.Form["d"];
            if (info.r.Length == 0 || info.o.Length == 0 || info.s.Length == 0 || info.d.Length ==0)
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
                    string sql = "UPDATE schedule " + "SET result=@r, opponents=@o, scoreline=@s, mdate=@d " +
                                 "WHERE matchday=@m";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@m", Request.Query["m"].ToString());
                        command.Parameters.AddWithValue("@r", info.r);
                        command.Parameters.AddWithValue("@o", info.o);
                        command.Parameters.AddWithValue("@s", info.s);
                        command.Parameters.AddWithValue("@d", info.d);
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
