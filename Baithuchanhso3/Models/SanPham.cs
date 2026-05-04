using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaiThucHanhSo3.Models
{
    public class SanPham
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sản phẩm không được để trống")]
        [StringLength(20, ErrorMessage = "Tối đa 20 ký tự")]
        [Display(Name = "Mã SP")]
        public string MaSP { get; set; } = "";

        [Required(ErrorMessage = "Tên sản phẩm không được để trống")]
        [StringLength(200, ErrorMessage = "Tối đa 200 ký tự")]
        [Display(Name = "Tên sản phẩm")]
        public string TenSP { get; set; } = "";

        [Range(0, double.MaxValue, ErrorMessage = "Đơn giá phải >= 0")]
        [Column(TypeName = "decimal(18,2)")]
        [Display(Name = "Đơn giá")]
        public decimal DonGia { get; set; }

        [StringLength(500)]
        [Display(Name = "Mô tả")]
        public string? MoTa { get; set; }

        // Navigation
        public ICollection<ChiTietDonHang>? ChiTietDonHangs { get; set; }
    }
}