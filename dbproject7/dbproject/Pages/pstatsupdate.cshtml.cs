using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class pstatsupdateModel : PageModel
    {
        public statedit info = new statedit();
        public string errormessage = "";
        public string smessage = "";

        public void OnGet()
        {
            string shirtno = Request.Query["shirtno"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM playerstats where shirtno=@shirtno";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("shirtno", shirtno);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.g = "" + reader.GetInt32(1);
                                info.a = "" + reader.GetInt32(2);
                                info.p = "" + reader.GetInt32(3);
                                info.d = "" + reader.GetInt32(4);
                                info.cs = "" + reader.GetInt32(5);
                                info.sld = "" + reader.GetInt32(6);
                                info.std = "" + reader.GetInt32(7);
                                info.dls = "" + reader.GetInt32(8);
                                info.i = "" + reader.GetInt32(9);
                                info.s = "" + reader.GetInt32(10);
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
            info.g = Request.Form["g"];
            info.a= Request.Form["a"];
            info.p= Request.Form["p"];
            info.d = Request.Form["d"];
            info.cs = Request.Form["cs"];
            info.sld = Request.Form["sld"];
            info.std = Request.Form["std"];
            info.dls = Request.Form["dls"];
            info.i = Request.Form["i"];
            info.s = Request.Form["s"];
            if (info.g.Length == 0 || info.a.Length == 0 || info.p.Length == 0 || info.s.Length == 0)
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
                    string sql = "UPDATE playerstats " + "SET goals=@g, assists=@a, passes=@p, dribbles=@d, chances=@cs, slidetackles=@sld, standtackles=@std, duels=@dls, interceptions=@i, saves=@s " +
                                 "WHERE shirtno=@shirtno";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@shirtno", Request.Query["shirtno"].ToString());
                        command.Parameters.AddWithValue("@g", info.g);
                        command.Parameters.AddWithValue("@a", info.a);
                        command.Parameters.AddWithValue("@p", info.p);
                        command.Parameters.AddWithValue("@d", info.d);
                        command.Parameters.AddWithValue("@cs", info.cs);
                        command.Parameters.AddWithValue("@sld", info.sld);
                        command.Parameters.AddWithValue("@std", info.std);
                        command.Parameters.AddWithValue("@dls", info.dls);
                        command.Parameters.AddWithValue("@i", info.i);
                        command.Parameters.AddWithValue("@s", info.s);
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
    public class statedit
    {
        public string shirtno = "";
        public string g = "";
        public string a = "";
        public string p = "";
        public string d = "";
        public string cs = "";
        public string sld = "";
        public string std = "";
        public string dls = "";
        public string i = "";
        public string s = "";
    }
}
