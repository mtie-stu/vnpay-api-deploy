using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
	public class UserController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult DichVuDangKy()
		{
			return View();
		}


	}
}
