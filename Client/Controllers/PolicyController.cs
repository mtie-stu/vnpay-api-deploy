using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
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
