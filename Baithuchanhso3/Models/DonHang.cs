using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThucHanhSo3.Models
{
    public class DonHang
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã đơn hàng không được để trống")]
        [StringLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        [Display(Name = "Mã ĐH")]
        public string MaDH { get; set; } = "";

        [Required(ErrorMessage = "Ngày đặt hàng không được để trống")]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày đặt")]
        public DateTime NgayDat { get; set; } = DateTime.Today;

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string TrangThai { get; set; } = "Đang xử lý";

        [StringLength(300)]
        [Display(Name = "Ghi chú")]
        public string? GhiChu { get; set; }

        // Khóa ngoại đến KhachHang
        [Required(ErrorMessage = "Vui lòng chọn khách hàng")]
        [Display(Name = "Khách hàng")]
        public int KhachHangId { get; set; }

        [ForeignKey("KhachHangId")]
        public KhachHang? KhachHang { get; set; }

        // Một đơn hàng có nhiều chi tiết
        public ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }

        // Tổng tiền (computed helper)
        [NotMapped]
        public decimal TongTien => ChiTietDonHangs?.Sum(ct => ct.ThanhTien) ?? 0;
    }
}