using System.ComponentModel.DataAnnotations;
using App.Models.ValueTypes;

namespace App.Models.InputModels.Docenti
{
    public class DocenteEditInputModel
    {
        public int Id { get; set; }

        public string IdDocente { get; set; }

        [Display(Name = "Nominativo Docente")]
        public string NominativoDocente { get; set; }

        [Display(Name = "Materia Insegnata")]
        public string MateriaInsegnata { get; set; }

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Residenza")]
        public string Residenza { get; set; }

        [Display(Name = "Costo orario")]
        public Money CostoOrario { get; set; }
    }
}