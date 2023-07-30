using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class xextendModel : PageModel
    {
        public List<xinfoshow> listofassists = new List<xinfoshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.pid,p.fname,p.lname,c.contract\r\nfrom playername p\r\njoin playercontact c on p.pid=c.pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                xinfoshow info = new xinfoshow();
                                info.pid = "" + reader.GetInt32(0);
                                info.fn = reader.GetString(1);
                                info.ln = reader.GetString(2);
    
                                info.ctr = "" + reader.GetInt32(3);
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
    public class xinfoshow
    {
        public string pid = "";
        public string fn = "";
        public string ln = "";
        public string ctr = "";
    }
}
