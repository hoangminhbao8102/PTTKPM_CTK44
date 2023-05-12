using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebHotelManagementSystem.Pages.ThongTinKhachSan
{
    public class IndexModel : PageModel
    {
        public List<ThongTinKhachSan> dsThongTinKhachSan = new List<ThongTinKhachSan>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=LAPTOP-01O105KM\\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM TTKhachSan";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ThongTinKhachSan ttKhachSan = new ThongTinKhachSan();
                                ttKhachSan.id = "" + reader.GetInt32(0);
                                ttKhachSan.name = reader.GetString(1);
                                ttKhachSan.type = reader.GetString(2);
                                ttKhachSan.address = reader.GetString(3);
                                ttKhachSan.phone = reader.GetString(4);

                                dsThongTinKhachSan.Add(ttKhachSan);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }
        }
    }

    public class ThongTinKhachSan
    {
        public String id;
        public String name;
        public String type;
        public String address;
        public String phone;
    }
}
