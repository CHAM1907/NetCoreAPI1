using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThucHanhSo3.Models
{
    public class ChiTietDonHang
    {
        public int Id { get; set; }

        // Khóa ngoại đến DonHang
        [Required]
        [Display(Name = "Đơn hàng")]
        public int DonHangId { get; set; }

        [ForeignKey("DonHangId")]
        public DonHang? DonHang { get; set; }

        // Khóa ngoại đến SanPham
        [Required(ErrorMessage = "Vui lòng chọn sản phẩm")]
        [Display(Name = "Sản phẩm")]
        public int SanPhamId { get; set; }

        [ForeignKey("SanPhamId")]
        public SanPham? SanPham { get; set; }

        [Required(ErrorMessage = "Số lượng không được để trống")]
        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải >= 1")]
        [Display(Name = "Số lượng")]
        public int SoLuong { get; set; }

        [Required(ErrorMessage = "Đơn giá không được để trống")]
        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải >= 0")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }

        // Thành tiền tính toán
        [NotMapped]
        [Display(Name = "Thành tiền")]
        public decimal ThanhTien => SoLuong * DonGia;
    }
}