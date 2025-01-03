using Microsoft.AspNetCore.Mvc;

namespace InternetShop.Web.Controllers
{
	public class PageNotFoundController : Controller
	{
        public IActionResult Index()
        {
            return View();
        }
    }
}
