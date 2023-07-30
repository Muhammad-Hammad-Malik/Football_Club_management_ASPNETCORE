using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class injurycreateModel : PageModel
    {
        public injuredcreate info = new injuredcreate ();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.incid = Request.Form["incid"];
            info.pid = Request.Form["pid"];
            info.itype = Request.Form["itype"];
            info.duration = Request.Form["duration"];
            if (info.pid.Length == 0 || info.itype.Length == 0 || info.duration.Length == 0 )
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
                    string sql = "INSERT INTO injury " + "(incid, pid, type, duration) " + "VALUES (@incid, @pid, @itype, @duration)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@incid", info.incid);
                        command.Parameters.AddWithValue("@pid", info.pid);
                        command.Parameters.AddWithValue("@itype", info.itype);
                        command.Parameters.AddWithValue("@duration", info.duration);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }

            info.pid = "";
            info.itype = "";
            info.duration = "";
            info.incid = "";
            smessage = "SUCCESSFULLY ADDED";
        }
    }
    public class injuredcreate
    {
        public string pid="";
        public string itype="";
        public string duration = "";
        public string incid = "";
    }

}
