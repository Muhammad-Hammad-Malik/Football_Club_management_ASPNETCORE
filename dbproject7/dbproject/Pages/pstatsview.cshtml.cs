using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class pstatsviewModel : PageModel
    {
        public List<statsshower> listofassists = new List<statsshower>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "select p.shirtno,p.fname,p.lname,c.goals,c.assists,c.passes,c.dribbles,c.chances,c.slidetackles,c.standtackles,c.duels,c.interceptions,c.saves\r\nfrom playername p\r\njoin playerstats c on p.shirtno=c.shirtno\r\n\r\n";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                statsshower info = new statsshower();
                                info.shirtno = ""+reader.GetInt32(0);
                                info.fname = reader.GetString(1);
                                info.lname = reader.GetString(2);
                                info.g= "" + reader.GetInt32(3);
                                info.a= "" + reader.GetInt32(4);
                                info.p= "" + reader.GetInt32(5);
                                info.d= "" + reader.GetInt32(6);
                                info.cs= "" + reader.GetInt32(7);
                                info.sld= "" + reader.GetInt32(8);
                                info.std= "" + reader.GetInt32(9);
                                info.dls= "" + reader.GetInt32(10);
                                info.i= "" + reader.GetInt32(11);
                                info.s= "" + reader.GetInt32(12);
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
    public class statsshower
    {
        public string fname = "";
        public string lname = "";
        public string shirtno = "";
        public string g = "";
        public string a = "";
        public string p = "";
        public string d = "";
        public string cs = "";
        public string sld = "";
        public string std = "";
        public string dls = "";
        public string i = "";
        public string s = "";

    }

}

