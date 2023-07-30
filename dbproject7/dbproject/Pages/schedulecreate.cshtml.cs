using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class schedulecreateModel : PageModel
    {
        public sshow info = new sshow();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.m = Request.Form["m"];
            info.r = Request.Form["r"];
            info.o = Request.Form["o"];
            info.s = Request.Form["s"];
            info.d = Request.Form["d"];
            if (info.m.Length == 0 || info.r.Length == 0 || info.o.Length == 0 || info.s.Length==0 || info.d.Length==0)
            {
                errormessage = "ALL THE FIELDS ARE COMPULSARY";
                return;
            }
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO schedule " + "(matchday, result, opponents, scoreline, mdate) " + "VALUES (@matchday, @result, @opponents, @scoreline, @mdate )";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@matchday", info.m);
                        command.Parameters.AddWithValue("@result", info.r);
                        command.Parameters.AddWithValue("@opponents", info.o);
                        command.Parameters.AddWithValue("@scoreline", info.s);
                        command.Parameters.AddWithValue("@mdate", info.d);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }

            info.m = "";
            info.r = "";
            info.o = "";
            info.s = "";
            info.d = "";
            smessage = "SUCCESSFULLY ADDED";
        }
    }
}
