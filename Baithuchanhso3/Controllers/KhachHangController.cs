using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BaiThucHanhSo3.Data;
using BaiThucHanhSo3.Models;

namespace BaiThucHanhSo3.Controllers
{
    public class KhachHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KhachHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===================== INDEX =====================
        public IActionResult Index()
        {
            var list = _context.KhachHangs.ToList();
            return View(list);
        }

        // ===================== DETAILS =====================
        public IActionResult Details(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh == null)
                return NotFound();
            return View(kh);
        }

        // ===================== CREATE (GET) =====================
        public IActionResult Create()
        {
            return View(new KhachHang());
        }

        // ===================== CREATE (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(KhachHang kh)
        {
            if (!ModelState.IsValid)
                return View(kh);

            _context.KhachHangs.Add(kh);
            _context.SaveChanges();
            TempData["Success"] = "Thêm khách hàng thành công!";
            return RedirectToAction("Index");
        }

        // ===================== EDIT (GET) =====================
        public IActionResult Edit(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh == null)
                return NotFound();
            return View(kh);
        }

        // ===================== EDIT (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(KhachHang kh)
        {
            if (!ModelState.IsValid)
                return View(kh);

            _context.KhachHangs.Update(kh);
            _context.SaveChanges();
            TempData["Success"] = "Cập nhật khách hàng thành công!";
            return RedirectToAction("Index");
        }

        // ===================== DELETE (GET) =====================
        public IActionResult Delete(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh == null)
                return NotFound();
            return View(kh);
        }

        // ===================== DELETE (POST) =====================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var kh = _context.KhachHangs.Find(id);
            if (kh == null)
                return NotFound();

            _context.KhachHangs.Remove(kh);
            _context.SaveChanges();
            TempData["Success"] = "Xóa khách hàng thành công!";
            return RedirectToAction("Index");
        }

        // ===================== XEM ĐƠN HÀNG THEO KHÁCH HÀNG =====================
        public IActionResult DonHangCuaKhach(int id)
        {
            var kh = _context.KhachHangs
                .Include(k => k.DonHangs!)
                    .ThenInclude(dh => dh.ChiTietDonHangs!)
                        .ThenInclude(ct => ct.SanPham)
                .FirstOrDefault(k => k.Id == id);

            if (kh == null)
                return NotFound();

            return View(kh);
        }
    }
}