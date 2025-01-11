using Business.ManagerServices;
using Business.ManagerServices.Abstracts;
using Business.ManagerServices.Concretes;
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
        private readonly DataGeneratorService _dataGeneratorService;

        public HomeController(ILogger<HomeController> logger, IRandomDataManager randomDataManager, IRandomDataTypeManager randomDataTypeManager, DataGeneratorService dataGeneratorService)
        {
            _logger = logger;
            _randomDataManager = randomDataManager;
            _randomDataTypeManager = randomDataTypeManager;
            _dataGeneratorService = dataGeneratorService;
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
            var result = await _randomDataManager.GetRandomlyByIds(model.NumberOfData, model.postData.Select(x => x.TypeId).ToList());
            var parameters = new Dictionary<string, object>
            {
            { "min", 1 },
            { "max", 100 }
            };

            var randomIntegers = _dataGeneratorService.GenerateData("Integer", 10, parameters);

            return View();
        }
        public IActionResult Error()
        {

            return View();
        }

        





    }
}
