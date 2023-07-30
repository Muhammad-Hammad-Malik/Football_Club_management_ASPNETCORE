using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;


namespace dbproject.Pages
{
    public class plreportModel : PageModel
    {
        public List<report> r = new List<report>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=.\\sqlexpress;Initial Catalog=club;Integrated Security=True";
                var income = 0;
                var cost = 0;
                report info = new report();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql1 = "SELECT SUM(i.amount) FROM income i";

                    using (SqlCommand command = new SqlCommand(sql1, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();

                                if (!reader.IsDBNull(0))
                                {
                                    income += reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql3 = "SELECT SUM(s.amount) FROM playersell s;";

                    using (SqlCommand command = new SqlCommand(sql3, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();

                                if (!reader.IsDBNull(0))
                                {
                                    income += reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }
                info.income = income.ToString();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql2 = "SELECT SUM(e.amount) FROM expenditures e";

                    using (SqlCommand command = new SqlCommand(sql2, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();

                                if (!reader.IsDBNull(0))
                                {
                                    cost += reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string sql4 = "SELECT SUM(e.amount) FROM playersigning e";

                    using (SqlCommand command = new SqlCommand(sql4, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();

                                if (!reader.IsDBNull(0))
                                {
                                    cost += reader.GetInt32(0);
                                }
                            }
                        }
                    }
                }
                info.cost = cost.ToString();
                r.Add(info);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXCEPTION THROWN");
            }
        }

    }
    public class report
    {
        public string cost;
        public string income;
    }

}
