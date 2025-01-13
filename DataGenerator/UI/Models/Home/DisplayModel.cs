namespace UI.Models.Home
{
    public class DisplayModel
    {
        public List<string> FieldNames { get; set; }
        public List<Dictionary<string, string>> Values { get; set; } = new List<Dictionary<string, string>>();
    }
}
