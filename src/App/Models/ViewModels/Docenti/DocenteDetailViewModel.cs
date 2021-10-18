using App.Models.ValueTypes;

namespace App.Models.ViewModels.Docenti
{
    public class DocenteDetailViewModel
    {
        public int Id { get; set; }
        public string IdDocente { get; set; }
        public string NominativoDocente { get; set; }
        public string MateriaInsegnata { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Residenza { get; set; }
        public Money CostoOrario { get; set; }
    }
}