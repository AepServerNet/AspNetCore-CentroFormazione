using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Docenti
{
    public class DocenteCreateInputModel
    {
        public string IdDocente { get; set; }
        
        [Required(ErrorMessage = "Il nominativo docente è obbligatorio"),
        Display(Name = "Nominativo Docente")]
        public string NominativoDocente { get; set; }

        [Required(ErrorMessage = "La materia insegnata è obbligatoria"),
        Display(Name = "Materia Insegnata")]
        public string MateriaInsegnata { get; set; }
    }
}