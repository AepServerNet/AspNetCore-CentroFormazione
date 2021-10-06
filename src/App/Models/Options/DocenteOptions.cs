namespace App.Models.Options
{
    public class DocenteOptions
    {
        public int PerPage { get; set; }
        public DocenteOrderOptions Order { get; set; }
    }

    public partial class DocenteOrderOptions
    {
        public string By { get; set; }
        public bool Ascending { get; set; }
        public string[] Allow { get; set; }
    }
}