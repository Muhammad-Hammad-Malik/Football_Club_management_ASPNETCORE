using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class schedModel : PageModel
    {
        public List<scheduler> listofclients = new List<scheduler>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * from [schedule]";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                scheduler info = new scheduler();
                                info.md = "" + reader.GetInt32(0);
                                info.r = reader.GetString(1);
                                info.op = reader.GetString(2);
                                info.sc = reader.GetString(3);
                                info.dt = reader.GetString(4);
                                listofclients.Add(info);
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
    public class scheduler
    {
        public string md="";
        public string r="";
        public string op="";
        public string sc="";
        public string dt="";
    }
}
