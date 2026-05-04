using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BaiThucHanhSo3.Data;
using BaiThucHanhSo3.Models;

namespace BaiThucHanhSo3.Controllers
{
    public class DonHangController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DonHangController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ===================== INDEX =====================
        public IActionResult Index()
        {
            var list = _context.DonHangs
                .Include(dh => dh.KhachHang)
                .Include(dh => dh.ChiTietDonHangs)
                .ToList();
            return View(list);
        }

        // ===================== DETAILS =====================
        public IActionResult Details(int id)
        {
            var dh = _context.DonHangs
                .Include(d => d.KhachHang)
                .Include(d => d.ChiTietDonHangs!)
                    .ThenInclude(ct => ct.SanPham)
                .FirstOrDefault(d => d.Id == id);

            if (dh == null)
                return NotFound();

            return View(dh);
        }

        // ===================== CREATE (GET) =====================
        public IActionResult Create()
        {
            LoadDropdowns();
            return View(new DonHang { NgayDat = DateTime.Today });
        }

        // ===================== CREATE (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DonHang dh)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns(dh.KhachHangId);
                return View(dh);
            }

            _context.DonHangs.Add(dh);
            _context.SaveChanges();
            TempData["Success"] = "Tạo đơn hàng thành công!";
            return RedirectToAction("Details", new { id = dh.Id });
        }

        // ===================== EDIT (GET) =====================
        public IActionResult Edit(int id)
        {
            var dh = _context.DonHangs.Find(id);
            if (dh == null)
                return NotFound();

            LoadDropdowns(dh.KhachHangId);
            return View(dh);
        }

        // ===================== EDIT (POST) =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DonHang dh)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns(dh.KhachHangId);
                return View(dh);
            }

            _context.DonHangs.Update(dh);
            _context.SaveChanges();
            TempData["Success"] = "Cập nhật đơn hàng thành công!";
            return RedirectToAction("Index");
        }

        // ===================== DELETE (GET) =====================
        public IActionResult Delete(int id)
        {
            var dh = _context.DonHangs
                .Include(d => d.KhachHang)
                .FirstOrDefault(d => d.Id == id);

            if (dh == null)
                return NotFound();

            return View(dh);
        }

        // ===================== DELETE (POST) =====================
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var dh = _context.DonHangs.Find(id);
            if (dh == null)
                return NotFound();

            _context.DonHangs.Remove(dh);
            _context.SaveChanges();
            TempData["Success"] = "Xóa đơn hàng thành công!";
            return RedirectToAction("Index");
        }

        // ===================== THÊM CHI TIẾT =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemChiTiet(ChiTietDonHang ct)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Dữ liệu không hợp lệ, vui lòng kiểm tra lại.";
                return RedirectToAction("Details", new { id = ct.DonHangId });
            }

            // Tự động lấy đơn giá từ sản phẩm nếu chưa nhập
            if (ct.DonGia <= 0)
            {
                var sp = _context.SanPhams.Find(ct.SanPhamId);
                if (sp != null) ct.DonGia = sp.DonGia;
            }

            _context.ChiTietDonHangs.Add(ct);
            _context.SaveChanges();
            TempData["Success"] = "Thêm sản phẩm vào đơn hàng thành công!";
            return RedirectToAction("Details", new { id = ct.DonHangId });
        }

        // ===================== XÓA CHI TIẾT =====================
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult XoaChiTiet(int chiTietId, int donHangId)
        {
            var ct = _context.ChiTietDonHangs.Find(chiTietId);
            if (ct != null)
            {
                _context.ChiTietDonHangs.Remove(ct);
                _context.SaveChanges();
                TempData["Success"] = "Đã xóa sản phẩm khỏi đơn hàng.";
            }
            return RedirectToAction("Details", new { id = donHangId });
        }

        // ===================== Helper =====================
        private void LoadDropdowns(int? selectedKhachHangId = null)
        {
            ViewBag.KhachHangId = new SelectList(
                _context.KhachHangs.OrderBy(k => k.HoTen),
                "Id", "HoTen", selectedKhachHangId);

            ViewBag.SanPhams = _context.SanPhams
                .OrderBy(s => s.TenSP)
                .Select(s => new { s.Id, s.TenSP, s.DonGia })
                .ToList();

            ViewBag.DanhSachTrangThai = new SelectList(new[]
            {
                "Đang xử lý", "Đã xác nhận", "Đang giao", "Hoàn thành", "Đã hủy"
            });
        }
    }
}