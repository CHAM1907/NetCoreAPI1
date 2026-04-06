using Microsoft.AspNetCore.Mvc;
using BaiThucHanhSo3.Data;
using BaiThucHanhSo3.Models;
using System.Linq;

namespace BaiThucHanhSo3.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ================== INDEX ==================
        public IActionResult Index()
        {
            var list = _context.Students.ToList();
            return View(list);
        }

        // ================== CREATE (GET) ==================
        public IActionResult Create()
        {
            return View();
        }

        // ================== CREATE (POST) ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Student student)
        {
            if (!ModelState.IsValid)
            {
                return View(student);
            }

            _context.Students.Add(student);
            _context.SaveChanges();
               // 👉 THÊM DÒNG NÀY
    TempData["Success"] = "Thêm sinh viên thành công!";

            return RedirectToAction("Index");
        }

        // ================== EDIT (GET) ==================
        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            return View(student);
        }

        // ================== EDIT (POST) ==================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Student student)
        {
            if (!ModelState.IsValid)
            {
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
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            return View(student);
        }

        // ================== DELETE (POST) ==================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return RedirectToAction("NotFoundPage", "Home");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();
    TempData["Success"] = "Xóa thông tin sinh viên thành công!";


            return RedirectToAction("Index");
        }
    }
}