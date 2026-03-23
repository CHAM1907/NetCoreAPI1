using Microsoft.AspNetCore.Mvc;
using BaiThucHanhSo3.Models;

namespace BaiThucHanhSo3.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string fullName)
        {
            ViewBag.Message = "Xin chào " + fullName;
            return View();
        }

        [HttpGet]
        public IActionResult StudentForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult StudentForm(Student student)
        {
            ViewBag.Result = $"MSSV: {student.StudentCode} - {student.FullName}";
            return View();
        }
    }
}