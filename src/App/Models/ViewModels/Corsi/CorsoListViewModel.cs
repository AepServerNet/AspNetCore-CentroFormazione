using App.Models.InputModels.Corsi;

namespace App.Models.ViewModels.Corsi
{
    public class CorsoListViewModel : IPaginationInfo
    {
        public ListViewModel<CorsoViewModel> Corso { get; set; }
        public CorsoListInputModel Input { get; set; }

        int IPaginationInfo.CurrentPage => Input.Page;
        int IPaginationInfo.TotalResults => Corso.TotalCount;
        int IPaginationInfo.ResultsPerPage => Input.Limit;

        string IPaginationInfo.Search => Input.Search;
        string IPaginationInfo.OrderBy => Input.OrderBy;

        bool IPaginationInfo.Ascending => Input.Ascending;
    }
}
