using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class canceloModel : PageModel
    {
        public List<playerdata> pdata = new List<playerdata>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    //change here
                    string sql = "select p.shirtno,p.fname,p.lname,p.age,p.nationality,s.goals,s.assists,s.passes,s.dribbles,s.chances,s.slidetackles,s.standtackles,s.duels,s.interceptions,s.saves,m.tvalue,p.position\r\nfrom playername p\r\njoin playerstats s on p.shirtno=s.shirtno\r\njoin playerfinancial m on p.pid=m.pid\r\nwhere s.shirtno=35;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            reader.Read();
                            playerdata info = new playerdata();
                            info.sn = "" + reader.GetInt32(0);
                            info.fn = reader.GetString(1);
                            info.ln = reader.GetString(2);
                            info.age = "" + reader.GetInt32(3);
                            info.nationality = reader.GetString(4);
                            info.goals = "" + reader.GetInt32(5);
                            info.assists = "" + reader.GetInt32(6);
                            info.passes = "" + reader.GetInt32(7);
                            info.dribbles = "" + reader.GetInt32(8);
                            info.chances = "" + reader.GetInt32(9);
                            info.slidetackles = "" + reader.GetInt32(10);
                            info.standtackles = "" + reader.GetInt32(11);
                            info.duels = "" + reader.GetInt32(12);
                            info.interceptions = "" + reader.GetInt32(13);
                            info.saves = "" + reader.GetInt32(14);
                            info.tvalue = "" + reader.GetInt32(15);
                            info.position = reader.GetString(16);
                            pdata.Add(info);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION THROWN");
            }
        }
        public class playerdata
        {
            public string sn = "";
            public string fn = "";
            public string ln = "";
            public string age = "";
            public string nationality = "";
            public string goals = "";
            public string assists = "";
            public string passes = "";
            public string dribbles = "";
            public string chances = "";
            public string slidetackles = "";
            public string standtackles = "";
            public string duels = "";
            public string interceptions = "";
            public string saves = "";
            public string tvalue = "";
            public string position = "";
        }
    }
}
