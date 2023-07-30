using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class xsellModel : PageModel
    {
        public List<sellshow> listofassists = new List<sellshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.pid, p.shirtno,p.fname,p.lname,f.tvalue\r\nfrom playername p\r\njoin playerfinancial f on p.pid=f.pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                sellshow info = new sellshow();
                                info.pid = "" + reader.GetInt32(0);
                                info.shirtno = "" + reader.GetInt32(1);
                                info.fn = reader.GetString(2);
                                info.ln = reader.GetString(3);
                                info.tvalue = ""+ reader.GetInt32(4);
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
    public class sellshow
    {
        public string pid = "";
        public string shirtno = "";
        public string fn = "";
        public string ln = "";
        public string tvalue = "";
    }
}
