namespace UI.Models
{
    public class RandomResultModel
    {
        public int NumberOfRecords { get; set; }

        public List<ColModel> Cols {  get; set; }  
    }

    public class ColModel
    {
        public string FieldName { get; set; }
        public string TypeKey { get; set; }
        public int TypeId { get; set; }
        public string GeneratorType { get; set; }
        public List<object> Values { get; set; }
    }
}
