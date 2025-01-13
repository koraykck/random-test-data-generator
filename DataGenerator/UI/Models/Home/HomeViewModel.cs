using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.Models
{
    public class HomeViewModel
    {
        public List<TypeModel> Types { get; set; }
        public List<GenerateDataModel> postData { get; set; }
        public int NumberOfData { get; set; }
    }

    public class GenerateDataModel
    {
        public int TypeId { get; set; }
        public string ColName { get; set; }
        public int? Min { get; set; }
        public int? Max { get; set; }
        public DateTime? start { get; set; }
        public DateTime? end { get; set; }
        public int? length { get; set; }
    }

}
