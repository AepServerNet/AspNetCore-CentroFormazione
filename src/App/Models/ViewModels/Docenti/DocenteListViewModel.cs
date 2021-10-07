using App.Models.InputModels.Docenti;

namespace App.Models.ViewModels.Docenti
{
    public class DocenteListViewModel : IPaginationInfo
    {
        public ListViewModel<DocenteViewModel> Docente { get; set; }
        public DocenteListInputModel Input { get; set; }

        int IPaginationInfo.CurrentPage => Input.Page;
        int IPaginationInfo.TotalResults => Docente.TotalCount;
        int IPaginationInfo.ResultsPerPage => Input.Limit;

        string IPaginationInfo.Search => Input.Search;
        string IPaginationInfo.OrderBy => Input.OrderBy;

        bool IPaginationInfo.Ascending => Input.Ascending;
    }
}