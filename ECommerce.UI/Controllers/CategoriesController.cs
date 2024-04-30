using ECommerce.Data.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ECommerce.UI.Controllers
{
    public class CategoriesController : Controller
    {
        private HttpClient _httpClient;

        public CategoriesController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IActionResult> Index()
        {
            var responseMessage = await _httpClient.GetAsync("https://localhost:7240/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonString = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<Category>>(jsonString);
                return View(values);
            }
            return NotFound("Category list could not be retrieved...");
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
