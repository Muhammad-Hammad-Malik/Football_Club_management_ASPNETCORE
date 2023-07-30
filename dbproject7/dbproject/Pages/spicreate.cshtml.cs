using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace dbproject.Pages
{
    public class spicreateModel : PageModel
    {
        public spishow info = new spishow();
        public string errormessage = "";
        public string smessage = "";
        public void OnGet()
        {
        }
        public void OnPost()
        {
            info.pid = Request.Form["pid"];
            info.agency_name = Request.Form["agency_name"];
            info.contact = Request.Form["contact"];
            info.address = Request.Form["address"];
            info.contract = Request.Form["contract"];
            if (info.pid.Length == 0 || info.agency_name.Length == 0 || info.contact.Length == 0 || info.address.Length == 0 || info.contract.Length == 0)
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
                    string sql = "INSERT INTO playercontact " + "(pid, agency_name, contact, address, contract) " + "VALUES (@pid, @agency_name, @contact, @address, @contract)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@pid", info.pid);
                        command.Parameters.AddWithValue("@agency_name", info.agency_name);
                        command.Parameters.AddWithValue("@contact", info.contact);
                        command.Parameters.AddWithValue("@address", info.address);
                        command.Parameters.AddWithValue("@contract", info.contract);
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
            info.agency_name = "";
            info.contact = "";
            info.address = "";
            info.contract = "";
            smessage = "SUCCESSFULLY ADDED";
        }
    }
    public class spishow
    {
        public string pid = "";
        public string agency_name = "";
        public string contact = "";
        public string address = "";
        public string contract = "";
    }
}
