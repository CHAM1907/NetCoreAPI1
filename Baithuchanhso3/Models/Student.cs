using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace BaiThucHanhSo3.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Mã sinh viên không được để trống")]
        [StringLength(10, ErrorMessage = "Tối đa 10 ký tự")]
        public string StudentCode { get; set; } = "";

        [Required(ErrorMessage = "Họ tên không được để trống")]
        [StringLength(50, ErrorMessage = "Tối đa 50 ký tự")]
        public string FullName { get; set; } = "";

        [Range(18, 60, ErrorMessage = "Tuổi phải từ 18 đến 60")]
        public int? Age { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string? Email { get; set; }

         // Khóa ngoại liên kết đến Faculty
        [Required(ErrorMessage = "Vui lòng chọn khoa")]
        [Display(Name = "Khoa")]
        public int FacultyId { get; set; }
 
        // Navigation property
        [ForeignKey("FacultyId")]
        public Faculty? Faculty { get; set; }
        
    }
}