using Business.ManagerServices.Abstracts;
using Business.ManagerServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using UI.Models;

namespace UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRandomDataManager _randomDataManager;
        private readonly IRandomDataTypeManager _randomDataTypeManager;

        public HomeController(ILogger<HomeController> logger, IRandomDataManager randomDataManager, IRandomDataTypeManager randomDataTypeManager)
        {
            _logger = logger;
            _randomDataManager = randomDataManager;
            _randomDataTypeManager = randomDataTypeManager;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomeViewModel();

            var allTypes = await _randomDataTypeManager.GetAllTypes();
            model.Types = allTypes.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.TypeId.ToString(),
            }).ToList();


            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateData(HomeViewModel model)
        {
            

            return View();
        }
        public IActionResult Error()
        {

            return View();
        }

        





    }
}
