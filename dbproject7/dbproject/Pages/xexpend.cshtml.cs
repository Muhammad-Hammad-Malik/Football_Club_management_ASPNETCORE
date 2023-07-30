using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class xexpendModel : PageModel
    {
        public List<incshow> listofassists = new List<incshow>();
        public List<xpincome> listofassists1 = new List<xpincome>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select * from expenditures;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                incshow info = new incshow();
                                info.iid = "" + reader.GetInt32(0);
                                info.n = reader.GetString(1);
                                info.t = reader.GetString(2);
                                info.a = "" + reader.GetInt32(3);
                                listofassists.Add(info);
                            }
                        }
                    }
                    string sql2 = "select * from playersigning;";
                    using (SqlCommand command2 = new SqlCommand(sql2, connection))
                    {
                        using (SqlDataReader reader = command2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                xpincome info1 = new xpincome();
                                info1.psid = "" + reader.GetInt32(0);
                                info1.pid = "" + reader.GetInt32(1);
                                info1.fname = reader.GetString(2);
                                info1.lname = reader.GetString(3);
                                info1.amount = "" + reader.GetInt32(4);
                                info1.date = "" + reader.GetDateTime(5).ToString();
                                listofassists1.Add(info1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION THROWN");
            }
        }
    }
}
