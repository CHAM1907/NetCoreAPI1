using Microsoft.AspNetCore.Mvc;

namespace BaiThucHanhSo3.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            string hoTen = "Ngo Ngoc Cham";
            string maSV = "2121050888";  

            ViewBag.Message = $"Hello {hoTen} - {maSV}";
            return View();
        }
    }
}