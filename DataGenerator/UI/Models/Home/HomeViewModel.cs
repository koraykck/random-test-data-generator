using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class HomeViewModel
    {
        public List<SelectListItem> Types { get; set; }
        public List<GenerateDataModel> postData { get; set; }
        public int NumberOfData { get; set; }
    }

    public class GenerateDataModel
    {
        public int TypeId { get; set; }
        public string ColName { get; set; }
    }

}
