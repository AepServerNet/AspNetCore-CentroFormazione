using App.Models.ValueTypes;
using System.Collections.Generic;

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

        //TODO:
        //public List<LezioneViewModel> Lezioni { get; set; } = new List<LezioneViewModel>();
    }
}