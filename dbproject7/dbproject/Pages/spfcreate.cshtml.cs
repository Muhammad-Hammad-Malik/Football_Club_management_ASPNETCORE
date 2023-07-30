using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class spfcreateModel : PageModel
    {
        public spfshow info = new spfshow();
        public psshow info2=new psshow();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.pid = Request.Form["pid"];
            info.tvalue = Request.Form["tvalue"];
            info.wages = Request.Form["wages"];
            info2.fname = Request.Form["fname"];
            info2.lname = Request.Form["lname"];
            if (info.pid.Length == 0 || info.tvalue.Length == 0 || info.wages.Length == 0)
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
                    string sql = "INSERT INTO playerfinancial " + "(pid, tvalue, wages) " + "VALUES (@pid, @tvalue, @wages)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pid", info.pid);
                        command.Parameters.AddWithValue("@tvalue", info.tvalue);
                        command.Parameters.AddWithValue("@wages", info.wages);
                        command.ExecuteNonQuery();
                    }

                    string sql2 = "INSERT INTO playersigning " + "(pid, fname, lname, amount) " + "VALUES (@pid, @fname, @lname ,@tvalue)";

                    using (SqlCommand command2 = new SqlCommand(sql2, connection))
                    {
                        command2.Parameters.AddWithValue("@pid", info.pid);
                        command2.Parameters.AddWithValue("@tvalue", info.tvalue);
                        command2.Parameters.AddWithValue("@fname", info2.fname);
                        command2.Parameters.AddWithValue("@lname", info2.lname);
                        command2.ExecuteNonQuery();
                    }

                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }

            info.pid = "";
            info.tvalue = "";
            info.wages = "";
            info2.fname = "";
            info2.lname = "";
            smessage = "SUCCESSFULLY ADDED";
        }
    }
    public class spfshow
    {
        public string pid = "";
        public string tvalue = "";
        public string wages = "";

    }
    public class psshow
    {
        public string fname = "";
        public string lname = "";
    }
}

