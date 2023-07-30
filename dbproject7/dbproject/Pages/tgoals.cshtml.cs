using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class tgoalsModel : PageModel
    {
        public List<statshow> listofgoals = new List<statshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.shirtno,p.fname,p.lname,s.goals\r\nfrom playername p\r\njoin playerstats s on p.shirtno=s.shirtno\r\norder by s.goals DESC;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                statshow info = new statshow();
                                info.sn = "" + reader.GetInt32(0);
                                info.fn = reader.GetString(1);
                                info.ln = reader.GetString(2);
                                info.att = "" + reader.GetInt32(3);
                                listofgoals.Add(info);
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
    public class statshow
    {
        public string sn = "";
        public string fn = "";
        public string ln = "";
        public string att = "";
    }
}

