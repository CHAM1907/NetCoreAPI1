using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThucHanhSo3.Data;
using BaiThucHanhSo3.Models;
using BaiThucHanhSo3.ViewModels;

namespace BaiThucHanhSo3.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================== INDEX — dùng ViewModel ==================
        public IActionResult Index()
        {
            // Include Faculty để lấy tên khoa, chiếu sang ViewModel
            var list = _context.Students
                .Include(s => s.Faculty)
                .Select(s => new StudentFacultyVM
                {
                    Id          = s.Id,
                    StudentCode = s.StudentCode,
                    FullName    = s.FullName,
                    Age         = s.Age,
                    Email       = s.Email,
                    FacultyName = s.Faculty != null ? s.Faculty.FacultyName : "Chưa phân khoa"
                })
                .ToList();

            return View(list);
        }

        // ================== CREATE (GET) ==================
        public IActionResult Create()
        {
            LoadFacultyDropdown();
            return View(new Student());
        }

        // ================== CREATE (POST) ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                LoadFacultyDropdown(student.FacultyId);
                return View(student);
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            TempData["Success"] = "Thêm sinh viên thành công!";

            return RedirectToAction("Index");
        }

        // ================== EDIT (GET) ==================
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return RedirectToAction("NotFoundPage", "Home");

            LoadFacultyDropdown(student.FacultyId);
            return View(student);
        }

        // ================== EDIT (POST) ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
                LoadFacultyDropdown(student.FacultyId);
                return View(student);
            }

            _context.Students.Update(student);
            _context.SaveChanges();
            TempData["Success"] = "Cập nhật thông tin sinh viên thành công!";

            return RedirectToAction("Index");
        }

        // ================== DELETE (GET) ==================
        public IActionResult Delete(int id)
        {
            var student = _context.Students
                .Include(s => s.Faculty)
                .FirstOrDefault(s => s.Id == id);

            if (student == null)
                return RedirectToAction("NotFoundPage", "Home");

            return View(student);
        }

        // ================== DELETE (POST) ==================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
                return RedirectToAction("NotFoundPage", "Home");

            _context.Students.Remove(student);
            _context.SaveChanges();
            TempData["Success"] = "Xóa thông tin sinh viên thành công!";

            return RedirectToAction("Index");
        }

        // ================== Helper: nạp danh sách khoa cho dropdown ==================
        private void LoadFacultyDropdown(int? selectedId = null)
        {
            ViewBag.FacultyId = new SelectList(
                _context.Faculties.OrderBy(f => f.FacultyName),
                "Id",
                "FacultyName",
                selectedId
            );
        }
    }
}