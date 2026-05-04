using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiThucHanhSo3.Data;
using BaiThucHanhSo3.Models;

namespace BaiThucHanhSo3.Controllers
{
    public class SanPhamController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SanPhamController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===================== INDEX =====================
        public IActionResult Index()
        {
            var list = _context.SanPhams.ToList();
            return View(list);
        }

        // ===================== CREATE (GET) =====================
        public IActionResult Create()
        {
            return View(new SanPham());
        }

        // ===================== CREATE (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SanPham sp)
        {
            if (!ModelState.IsValid)
                return View(sp);

            _context.SanPhams.Add(sp);
            _context.SaveChanges();
            TempData["Success"] = "Thêm sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        // ===================== EDIT (GET) =====================
        public IActionResult Edit(int id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp == null)
                return NotFound();
            return View(sp);
        }

        // ===================== EDIT (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SanPham sp)
        {
            if (!ModelState.IsValid)
                return View(sp);

            _context.SanPhams.Update(sp);
            _context.SaveChanges();
            TempData["Success"] = "Cập nhật sản phẩm thành công!";
            return RedirectToAction("Index");
        }

        // ===================== DELETE (GET) =====================
        public IActionResult Delete(int id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp == null)
                return NotFound();
            return View(sp);
        }

        // ===================== DELETE (POST) =====================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var sp = _context.SanPhams.Find(id);
            if (sp == null)
                return NotFound();

            _context.SanPhams.Remove(sp);
            _context.SaveChanges();
            TempData["Success"] = "Xóa sản phẩm thành công!";
            return RedirectToAction("Index");
        }
    }
}