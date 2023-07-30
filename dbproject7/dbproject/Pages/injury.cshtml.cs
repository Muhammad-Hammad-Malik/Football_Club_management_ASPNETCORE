using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class injuryModel : PageModel
    {
        public List<injshow> listofassists = new List<injshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select i.incid,p.fname,p.lname,i.type,i.duration\r\nfrom playername p\r\njoin injury i on p.pid=i.pid;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                injshow info = new injshow();
                                info.incid = "" + reader.GetInt32(0);
                                info.fn = reader.GetString(1);
                                info.ln = reader.GetString(2);
                                info.t = reader.GetString(3);
                                info.d = "" + reader.GetInt32(4);
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
    public class injshow
    {
        public string incid = "";
        public string fn = "";
        public string ln = "";
        public string t = "";
        public string d = "";
    }
}
