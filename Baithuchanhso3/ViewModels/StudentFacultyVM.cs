namespace BaiThucHanhSo3.ViewModels
{
    /// <summary>
    /// ViewModel hiển thị thông tin sinh viên kèm tên khoa
    /// </summary>
    public class StudentFacultyVM
    {
        public int Id { get; set; }

        public string StudentCode { get; set; } = "";   // Mã sinh viên

        public string FullName { get; set; } = "";       // Họ tên

        public int? Age { get; set; }                    // Tuổi

        public string? Email { get; set; }               // Email

        public string FacultyName { get; set; } = "";   // Tên khoa (từ bảng Faculty)
    }
}