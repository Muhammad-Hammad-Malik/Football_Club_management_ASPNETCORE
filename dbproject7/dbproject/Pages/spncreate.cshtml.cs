using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class spncreateModel : PageModel
    {
        public spnshow info = new spnshow();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.pid = Request.Form["pid"];
            info.fname = Request.Form["fname"];
            info.lname = Request.Form["lname"];
            info.age = Request.Form["age"];
            info.position = Request.Form["position"];
            info.shirtno = Request.Form["shirtno"];
            info.nationality = Request.Form["nationality"];
            if (info.pid.Length == 0 || info.fname.Length == 0 || info.lname.Length == 0 || info.age.Length == 0|| info.position.Length == 0 || info.shirtno.Length == 0 || info.nationality.Length == 0)
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
                    string sql = "INSERT INTO playername " + "(pid, fname, lname, age, position ,shirtno, nationality) " + "VALUES (@pid, @fname, @lname, @age, @position, @shirtno, @nationality)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pid", info.pid);
                        command.Parameters.AddWithValue("@fname", info.fname);
                        command.Parameters.AddWithValue("@lname", info.lname);
                        command.Parameters.AddWithValue("@age", info.age);
                        command.Parameters.AddWithValue("@position", info.position);
                        command.Parameters.AddWithValue("@shirtno", info.shirtno);
                        command.Parameters.AddWithValue("@nationality", info.nationality);
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
            info.fname = "";
            info.lname = "";
            info.age = "";
            info.position = "";
            info.shirtno = "";
            info.nationality = "";
            smessage = "SUCCESSFULLY ADDED";
        }
    }
    public class spnshow
    {
        public string pid = "";
        public string fname = "";
        public string lname = "";
        public string age = "";
        public string position = "";
        public string shirtno = "";
        public string nationality = "";
    }
}
