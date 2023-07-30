using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class spscreateModel : PageModel
    {
        public spsshow info = new spsshow();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.shirtno = Request.Form["shirtno"];
            info.goals = Request.Form["goals"];
            info.assists = Request.Form["assists"];
            info.passes = Request.Form["passes"];
            info.chances = Request.Form["chances"];
            info.dribbles = Request.Form["dribbles"];
            info.slidetackles = Request.Form["slidetackles"];
            info.standtackles = Request.Form["standtackles"];
            info.duels = Request.Form["duels"];
            info.interceptions = Request.Form["interceptions"];
            info.saves = Request.Form["saves"];

            if (info.shirtno.Length == 0 || info.goals.Length == 0 || info.assists.Length == 0 || info.passes.Length == 0 || info.dribbles.Length == 0 || info.chances.Length == 0 || info.slidetackles.Length == 0 || info.standtackles.Length == 0 || info.duels.Length == 0 || info.interceptions.Length == 0 || info.saves.Length == 0)
            {
                errormessage = "ALL THE FIELDS ARE COMPULSARY";
                return;
            }
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "INSERT INTO playerstats " + "(shirtno, goals, assists, passes, dribbles, chances, slidetackles, standtackles, duels, interceptions ,saves) " + "VALUES (@sn, @g, @a, @p, @d, @c, @sld, @std, @dls, @i, @s)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@sn", info.shirtno);
                        command.Parameters.AddWithValue("@g", info.goals);
                        command.Parameters.AddWithValue("@a", info.assists);
                        command.Parameters.AddWithValue("@p", info.passes);
                        command.Parameters.AddWithValue("@d", info.dribbles);
                        command.Parameters.AddWithValue("@c", info.chances);
                        command.Parameters.AddWithValue("@sld", info.slidetackles);
                        command.Parameters.AddWithValue("@std", info.standtackles);
                        command.Parameters.AddWithValue("@dls", info.duels);
                        command.Parameters.AddWithValue("@i", info.interceptions);
                        command.Parameters.AddWithValue("@s", info.saves);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }

            info.shirtno = "";
            info.goals = "";
            info.assists = "";
            info.passes = "";
            info.dribbles = "";
            info.chances = "";
            info.slidetackles = "";
            info.standtackles = "";
            info.duels = "";
            info.interceptions = "";
            info.saves = "";
            smessage = "SUCCESSFULLY ADDED";
        }
    }
    public class spsshow
    {
        public string shirtno = "";
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

    }
}
