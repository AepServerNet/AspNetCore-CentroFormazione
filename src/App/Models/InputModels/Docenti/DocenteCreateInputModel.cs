using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Docenti
{
    public class DocenteCreateInputModel
    {
        public string IdDocente { get; set; }
        
        [Display(Name = "Nominativo Docente")]
        public string NominativoDocente { get; set; }

        [Display(Name = "Materia Insegnata")]
        public string MateriaInsegnata { get; set; }
    }
}