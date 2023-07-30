using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class viewscheduleModel : PageModel
    {
        public List <sshow> listofassists = new List<sshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select * from schedule";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sshow info = new sshow();
                                info.m = "" + reader.GetInt32(0);
                                info.r = reader.GetString(1);
                                info.o = reader.GetString(2);
                                info.s = reader.GetString(3);
                                info.d = reader.GetString(4);
                                listofassists.Add(info);
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
    public class sshow
    {
        public string m = "";
        public string r = "";
        public string o = "";
        public string s = "";
        public string d = "";
    }
}
