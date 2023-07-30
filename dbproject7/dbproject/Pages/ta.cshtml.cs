using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class taModel : PageModel
    {
        public List<statshow> listofassists = new List<statshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.shirtno,p.fname,p.lname,s.assists\r\nfrom playername p\r\njoin playerstats s on p.shirtno=s.shirtno\r\norder by s.assists DESC;";
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
}

