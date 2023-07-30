using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class xextendeditModel : PageModel
    {
        public xinfoedit info = new xinfoedit();
        public string errormessage = "";
        public string smessage = "";

        public void OnGet()
        {
            string pid = Request.Query["pid"];
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "SELECT * FROM playercontact where pid=@pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("pid", pid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                info.ctr = "" + reader.GetInt32(4);
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }
        }
        public void OnPost()
        {
    
            info.ctr = Request.Form["ctr"];
            if (info.ctr.Length == 0)
            {
                errormessage = "ALL FIELDS MUST BE FILLED";
                return;
            }
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string sql = "UPDATE playercontact " + "SET contract=@ctr " +
                                 "WHERE pid=@pid";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pid", Request.Query["pid"].ToString());
   
                        command.Parameters.AddWithValue("@ctr", info.ctr);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }
        }
    }
    public class xinfoedit
    {
        public string pid = "";
        public string ctr = "";
    }
}
