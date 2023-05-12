using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using System.Collections.Concurrent;

namespace WebHotelManagementSystem.Pages.ChuKhachSan
{
    public class IndexModel : PageModel
    {
        public List<ChuKhachSan> dsChuKhachSan = new List<ChuKhachSan>();
        public void OnGet()
        {
            try
            {
                String connectionString = "Data Source=LAPTOP-01O105KM\\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "SELECT * FROM ChuKhachSan";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ChuKhachSan chuKhachSan = new ChuKhachSan();
                                chuKhachSan.id = "" + reader.GetInt32(0);
                                chuKhachSan.name = reader.GetString(1);
                                chuKhachSan.gender = reader.GetString(2);
                                chuKhachSan.idCard = reader.GetString(3);
                                chuKhachSan.address = reader.GetString(4);
                                chuKhachSan.phone = reader.GetString(5);
                                chuKhachSan.email = reader.GetString(6);
                                chuKhachSan.username = reader.GetString(7);
                                chuKhachSan.password = reader.GetString(8);

                                dsChuKhachSan.Add(chuKhachSan);
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

    public class ChuKhachSan
    {
        public String id;
        public String name;
        public String gender;
        public String idCard;
        public String address;
        public String phone;
        public String email;
        public String username;
        public String password;
    }
}
