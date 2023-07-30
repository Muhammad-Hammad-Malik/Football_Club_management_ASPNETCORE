using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class pinfoupdateModel : PageModel
    {
        public infoedit info = new infoedit();
        public string errormessage = "";
        public string smessage = "";

        public void OnGet()
        {
            string pid = Request.Query["pid"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM playercontact where pid=@pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("pid", pid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.ad = reader.GetString(1);
                                info.ag = reader.GetString(2);
                                info.cnt=reader.GetString(3);
                                info.ctr = ""+ reader.GetInt32(4);
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
            info.ad = Request.Form["ad"];
            info.ag = Request.Form["ag"];
            info.cnt = Request.Form["cnt"];
            info.ctr = Request.Form["ctr"];
            if (info.ad.Length == 0 || info.ag.Length == 0 || info.cnt.Length == 0 || info.ctr.Length == 0)
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
                    string sql = "UPDATE playercontact " + "SET agency_name=@ag, contact=@cnt, address=@ad, contract=@ctr " +
                                 "WHERE pid=@pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pid", Request.Query["pid"].ToString());
                        command.Parameters.AddWithValue("@ag", info.ag);
                        command.Parameters.AddWithValue("@cnt", info.cnt);
                        command.Parameters.AddWithValue("@ad", info.ad);
                        command.Parameters.AddWithValue("@ctr", info.ctr);

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
    public class infoedit
    {
        public string pid = "";
        public string ad = "";
        public string ag = "";
        public string cnt = "";
        public string ctr = "";
    }
}

