using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace WebHotelManagementSystem.Pages.ThongTinKhachSan
{
    public class ThemMoiModel : PageModel
    {
        public String errorMessage = "";
        public String successMessage = "";
        public ThongTinKhachSan ttKhachSan = new ThongTinKhachSan();
        public void OnGet()
        {
        }

        public void OnPost() 
        {
            ttKhachSan.name = Request.Form["name"];
            ttKhachSan.type = Request.Form["type"];
            ttKhachSan.address = Request.Form["address"];
            ttKhachSan.phone = Request.Form["phone"];

            if (ttKhachSan.name.Length == 0 || ttKhachSan.type.Length == 0 || ttKhachSan.address.Length == 0 || ttKhachSan.phone.Length == 0)
            {
                errorMessage = "Vui lòng nhập lại!";
                return;
            }

            try
            {
                String connectionString = "Data Source=LAPTOP-01O105KM\\SQLEXPRESS;Initial Catalog=QuanLyKhachSan;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    String sql = "INSERT INTO TTKhachSan " +
                        "(TenKhachSan, LoaiKhachSan, DiaChi, SoDienThoa) VALUES " +
                        "(@TenKhachSan, @LoaiKhachSan, @DiaChi, @SoDienThoai);";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@TenKhachSan", ttKhachSan.name);
                        command.Parameters.AddWithValue("@LoaiKhachSan", ttKhachSan.type);
                        command.Parameters.AddWithValue("@DiaChi", ttKhachSan.address);
                        command.Parameters.AddWithValue("@SoDienThoai", ttKhachSan.phone);

                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            ttKhachSan.name = "";
            ttKhachSan.type = "";
            ttKhachSan.address = "";
            ttKhachSan.phone = "";
            successMessage = "Thêm khách sạn thành công!";

            Response.Redirect("/ThongTinKhachSan/Index");
        }
    }
}
