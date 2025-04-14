using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Models;
using User.Models.ViewModel;

namespace User.Controllers;

//[Authorize]
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IHttpClientFactory _httpClientFactory;

   
    public HomeController(ILogger<HomeController> logger, IHttpClientFactory httpClientFactory)
    {
        _logger = logger;
        _httpClientFactory = httpClientFactory;

    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Index2()
    {
        var token = Request.Cookies["JwtToken"];
        if (string.IsNullOrEmpty(token))
        {
            return RedirectToAction("Login", "Account");
        }

        var client = _httpClientFactory.CreateClient("MyApiClient");
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

        var response = await client.GetAsync("UserStorageOrder/GetAllByUser");

        if (!response.IsSuccessStatusCode)
        {
            return View("Error", $"Không thể tải đơn hàng: {response.ReasonPhrase}");
        }

        var ordersJson = await response.Content.ReadAsStringAsync();
        var orders = JsonSerializer.Deserialize<List<UserStorageViewModel>>(ordersJson,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        return View(orders);
    }


    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
