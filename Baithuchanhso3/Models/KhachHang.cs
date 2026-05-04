using System.ComponentModel.DataAnnotations;

namespace BaiThucHanhSo3.Models
{
    public class KhachHang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã khách hàng không được để trống")]
        [StringLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        [Display(Name = "Mã KH")]
        public string MaKH { get; set; } = "";

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(100, ErrorMessage = "Tối đa 100 ký tự")]
        [Display(Name = "Họ tên")]
        public string HoTen { get; set; } = "";

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        [StringLength(15)]
        [Display(Name = "Điện thoại")]
        public string? SoDienThoai { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string? Email { get; set; }

        [StringLength(250)]
        [Display(Name = "Địa chỉ")]
        public string? DiaChi { get; set; }

        // Navigation: một khách hàng có nhiều đơn hàng
        public ICollection<DonHang>? DonHangs { get; set; }
    }
}