using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class pinfoModel : PageModel
    {
        public List<infoshow> listofassists = new List<infoshow>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.pid,p.fname,p.lname,c.address,c.agency_name,c.contact,c.contract\r\nfrom playername p\r\njoin playercontact c on p.pid=c.pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                infoshow info = new infoshow();
                                info.pid = "" + reader.GetInt32(0);
                                info.fn = reader.GetString(1);
                                info.ln = reader.GetString(2);
                                info.ad = reader.GetString(3);
                                info.ag= reader.GetString(4);
                                info.cnt= reader.GetString(5);  
                                info.ctr = "" + reader.GetInt32(6);
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
    public class infoshow
    {
        public string pid = "";
        public string fn = "";
        public string ln = "";
        public string ad = "";
        public string ag = "";
        public string cnt = "";
        public string ctr = "";
    }
}

