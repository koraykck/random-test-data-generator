using Business.Extensions;
using Business.ManagerServices;
using Business.ManagerServices.Abstracts;
using Business.ManagerServices.Concretes;
using Business.ManagerServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using UI.Helpers;
using UI.Models;
using UI.Models.Home;

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
            model.Types = allTypes.Select(x => new TypeModel
            {
                TypeName = x.Name,
                TypeId = x.TypeId,
                TypeKey = x.Key,
            }).ToList();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> GenerateData(HomeViewModel model)
        {
            var resultModel = new RandomResultModel();
            resultModel.Cols = new List<ColModel>();
            resultModel.NumberOfRecords = model.NumberOfData;
            var types = await _randomDataTypeManager.GetTypesByIds(model.postData.Select(x=> x.TypeId).ToList());           
            foreach (var data in model.postData)
            {
                var type = types.Where(x => x.TypeId == data.TypeId).FirstOrDefault();
                ColModel colModel = new ColModel(); 
                colModel.FieldName = data.ColName;
                colModel.TypeId = type.TypeId;
                colModel.TypeKey = type.TypeKey;
                colModel.GeneratorType  = type.GeneratorKey;
                var parameters = new Dictionary<string, object>
                {
                    {"typeId", colModel.TypeId },
                    {"min", data.Min.HasValue ? data.Min.Value : 0 },
                    {"max", data.Max.HasValue ? data.Max.Value : 10 },
                    {"start", data.start.HasValue ? data.start.Value : DateTime.Now},
                    {"end", data.end.HasValue ? data.end.Value : DateTime.Now.AddDays(10) },
                    {"length", data.length.HasValue ? data.length.Value : 10 }
                };
                if(colModel.GeneratorType == "db")
                {
                    colModel.Values = _dataGeneratorService.GenerateData("db", resultModel.NumberOfRecords, parameters);
                }
                else
                {
                    colModel.Values = _dataGeneratorService.GenerateData(colModel.TypeKey, resultModel.NumberOfRecords, parameters);
                }
                resultModel.Cols.Add(colModel);
            }

            var flattenedList = FormatHelper.FlattenColsToRow(resultModel);
            var rules  = types.CheckRule();
            var formattedList = FormatHelper.ApplyRules(flattenedList, rules);


            DisplayModel viewModel = new DisplayModel();

            viewModel.FieldNames = formattedList
            .SelectMany(dict => dict.Keys)
            .Distinct()
            .ToList();

            viewModel.Values = FormatHelper.ConvertToListOfStringDictionaries(formattedList);

            return View(viewModel);
        }



        public IActionResult Error()
        {

            return View();
        }

        





    }
}
