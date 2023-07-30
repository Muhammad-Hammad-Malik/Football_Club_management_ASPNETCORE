using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class execpinfoModel : PageModel
    {
        public List<xinfo> listofassists = new List<xinfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.pid,p.fname,p.lname,p.age,c.address,c.agency_name,c.contact,c.contract,f.tvalue,f.wages\r\nfrom playername p\r\njoin playercontact c on p.pid=c.pid\r\njoin playerfinancial f on f.pid=p.pid;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                xinfo info = new xinfo();
                                info.pid = "" + reader.GetInt32(0);
                                info.fn = reader.GetString(1);
                                info.ln = reader.GetString(2);
                                info.a = "" + reader.GetInt32(3);
                                info.ad = reader.GetString(4);
                                info.ag = reader.GetString(5);
                                info.cnt = reader.GetString(6);
                                info.ctr = "" + reader.GetInt32(7);
                                info.v = "" + reader.GetInt32(8);
                                info.w = "" + reader.GetInt32(9);
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
    public class xinfo
    {
        public string pid = "";
        public string fn = "";
        public string ln = "";
        public string a = "";
        public string ad = "";
        public string ag = "";
        public string cnt = "";
        public string ctr = "";
        public string v = "";
        public string w = "";
    }
}
