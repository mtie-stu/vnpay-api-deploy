using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    public class PolicyController : Controller
    {
        // GET: /Policy/Terms
        public ActionResult Terms()
        {
            return View();
        }

        // GET: /Policy/Privacy
        public ActionResult Privacy()
        {
            return View();
        }
    }
}
