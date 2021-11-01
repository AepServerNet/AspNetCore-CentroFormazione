namespace App.Models.Options
{
    public class CorsoOptions
    {
        public int PerPage { get; set; }
        public CorsoOrderOptions Order { get; set; }
    }

    public partial class CorsoOrderOptions
    {
        public string By { get; set; }
        public bool Ascending { get; set; }
        public string[] Allow { get; set; }
    }
}
