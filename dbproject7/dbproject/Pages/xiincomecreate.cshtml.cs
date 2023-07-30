using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class xiincomecreateModel : PageModel
    {
        public xincomecreate info = new xincomecreate();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.iid = Request.Form["iid"];
            info.n = Request.Form["n"];
            info.t = Request.Form["t"];
            info.a = Request.Form["a"];
            if (info.iid.Length == 0 || info.n.Length == 0 || info.t.Length == 0 || info.a.Length==0)
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
                    string sql = "INSERT INTO income " + "(iid, iname, itype, amount) " + "VALUES (@iid, @n, @t, @a)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@iid", info.iid);
                        command.Parameters.AddWithValue("@n", info.n);
                        command.Parameters.AddWithValue("@t", info.t);
                        command.Parameters.AddWithValue("@a", info.a);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errormessage = ex.Message;
                return;
            }

            info.iid = "";
            info.n = "";
            info.t = "";
            info.a = "";
            smessage = "SUCCESSFULLY ADDED";
        }

    }
    public class xincomecreate
    {
        public string iid = "";
        public string n = "";
        public string t = "";
        public string a = "";
    }
}
