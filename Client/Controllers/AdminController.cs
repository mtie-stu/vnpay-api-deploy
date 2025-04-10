using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{

    public class AdminController : Controller
    {

        public IActionResult Index()
        {
            if (!User.IsInRole("Admin"))
                return RedirectToAction("AccessDenied", "Account");

            return View();
        }

        public IActionResult QuanLyDichVu()
        {
            return View();
        }

        public IActionResult QuanLyUser()
        {
            return View();
        }
        public IActionResult BaoCaoThongKe()
        {
            return View();
        }
    }
}
