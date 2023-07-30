using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class signinanalModel : PageModel
    {
        SqlConnection con = new SqlConnection("Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True");

        [BindProperty]
        public string username { get; set; }

        [BindProperty]
        public string password { get; set; }

        public void OnGet()
        {

        }


        public bool LoginCheck(string username, string password)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM analyst WHERE Username = @username AND Password = @password", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);
            int count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return count > 0;
        }
        public IActionResult OnPost()
        {
            string username = Request.Form["username"];
            string password = Request.Form["password"];
            if (LoginCheck(username, password))
            {
                return RedirectToPage("/analyst");
            }
            else
            {
                TempData["msg"] = "Invalid username or password";
                return Page();
            }
        }
    }
    public class anallogin
    {
        public string username { get; set; }
        public string password { get; set; }
    }
}
