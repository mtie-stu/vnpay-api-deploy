using Microsoft.AspNetCore.Mvc;

namespace User.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IHttpClientFactory _http;

        public PaymentController(IHttpClientFactory http)
        {
            _http = http;
        }

       
    }

}
