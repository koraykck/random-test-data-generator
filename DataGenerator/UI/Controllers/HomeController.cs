using Business.Extensions;
using Business.ManagerServices;
using Business.ManagerServices.Abstracts;
using Business.ManagerServices.Concretes;
using Business.ManagerServices.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;
using UI.Helpers;
using UI.Models;
using UI.Models.Home;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

        public IActionResult Index()
        {
            var model = new HomeViewModel();

            var allTypes = _randomDataTypeManager.GetAllTypes();
            model.Types = allTypes.Select(x => new TypeModel
            {
                TypeName = x.Name,
                TypeId = x.TypeId,
                TypeKey = x.Key,
            }).ToList();
            
            return View(model);
        }

        [HttpPost]
        public IActionResult GenerateData(HomeViewModel model)
        {
            var resultModel = new RandomResultModel();
            resultModel.Cols = new List<ColModel>();
            resultModel.NumberOfRecords = model.NumberOfData;
            var types = _randomDataTypeManager.GetTypesByIds(model.postData.Select(x=> x.TypeId).ToList());           
            foreach (var data in model.postData)
            {
                var type = types.Where(x => x.TypeId == data.TypeId).First();
                ColModel colModel = new ColModel(); 
                colModel.FieldName = data.ColName.Trim();
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
            HttpContext.Session.SetObject("rand-data", viewModel.Values);
            TempData["success"] = "Datas are successfully generated";
            return View(viewModel);
        }

        public IActionResult DownloadAsJSON()
        {
            var sessionData = GetSessionData();

            if (sessionData != null){
                string timeStamp = (DateTime.Now).ToString("yyyyMMddHHmm");
                return File(Encoding.UTF8.GetBytes(FormatToJSONString(sessionData)), "application/json", $"{timeStamp}RGD.json");
            }

            return RedirectToAction("Error");
        }

        public IActionResult DownloadAsCSV()
        {
            var sessionData = GetSessionData();

            if (sessionData != null)
            {
                string timeStamp = (DateTime.Now).ToString("yyyyMMddHHmm");
                return File(Encoding.UTF8.GetBytes(FormatToCSV(sessionData)), "text/csv", $"{timeStamp}RGD.csv");
            }

            return RedirectToAction("Error");
        }
      
        public IActionResult DownloadAsSQLScript()
        {
            var sessionData = GetSessionData();

            if (sessionData != null)
            {
                string timeStamp = (DateTime.Now).ToString("yyyyMMddHHmm");
                return File(Encoding.UTF8.GetBytes(FormatToSQLString(sessionData)), "application/sql", $"{timeStamp}RGD.sql");
            }
            return RedirectToAction("Error");
        }

        public IActionResult Error()
        {

            return View();
        }

        [NonAction]
        private List<Dictionary<string, string>>? GetSessionData()
        {
            if (HttpContext.Session.GetObject<List<Dictionary<string, string>>>("rand-data") != null)
            {
                return HttpContext.Session.GetObject<List<Dictionary<string, string>>>("rand-data");
            }
            return null;
        }

        [NonAction]
        private string FormatToJSONString(List<Dictionary<string, string>> model)
        {
            return JsonConvert.SerializeObject(model, Formatting.Indented);
        }

        [NonAction]
        private string FormatToCSV(List<Dictionary<string, string>> model)
        {
            var csvString = new StringBuilder();
            var fieldNames = string.Join(",", model[0].Keys);
            csvString.AppendLine(fieldNames);
            model.ForEach(x => { csvString.AppendLine(string.Join(",", x.Values)); });
            return csvString.ToString();
        }

        [NonAction]
        private string FormatToSQLString(List<Dictionary<string, string>> model)
        {
            var sqlString = new StringBuilder();
            foreach (var row in model)
            {
                var values = string.Join(",", row.Values.Select(value => $"'{value}'"));
                sqlString.AppendLine($"INSERT INTO Table ({string.Join(",", row.Keys)}) VALUES ({values});");
            }
            return sqlString.ToString();
        }

    }
}
