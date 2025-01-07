using Microsoft.AspNetCore.Mvc;

namespace UI.Controllers
{
	public class RandomDataController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
