namespace App.Models.Options
{
    public class EdificioOptions
    {
        public int PerPage { get; set; }
        public EdificioOrderOptions Order { get; set; }
    }

    public partial class EdificioOrderOptions
    {
        public string By { get; set; }
        public bool Ascending { get; set; }
        public string[] Allow { get; set; }
    }
}