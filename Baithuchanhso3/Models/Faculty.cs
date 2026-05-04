using System.ComponentModel.DataAnnotations;

namespace BaiThucHanhSo3.Models
{
    public class Faculty
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tên khoa không được để trống")]
        [StringLength(100)]
        [Display(Name = "Tên khoa")]
        public string FacultyName { get; set; } = "";

        // Một khoa có nhiều sinh viên
        public ICollection<Student>? Students { get; set; }
    }
}