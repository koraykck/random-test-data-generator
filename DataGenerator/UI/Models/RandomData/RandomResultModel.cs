using Business.ManagerServices.DTOs;

namespace UI.Models
{
    public class RandomResultModel
    {
        public int NumberOfRecords { get; set; }

        public List<string> GivenTypes { get; set; }

        public List<ColModel> Cols {  get; set; }  
    }

    public class ColModel
    {
        public string FieldName { get; set; }
        public string TypeKey { get; set; }
        public int TypeId { get; set; }
        public string GeneratorType { get; set; }
        public List<RandomDataDTO> Values { get; set; } = new List<RandomDataDTO>();
    }
}
