using System.ComponentModel.DataAnnotations;
using App.Models.ValueTypes;

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

        [Display(Name = "Telefono")]
        public string Telefono { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Residenza")]
        public string Residenza { get; set; }

        [Display(Name = "Codice Corso")]
        public string CodiceCorso { get; set; }

        [Display(Name = "Codice Dipartimento")]
        public string CodiceDipartimento { get; set; }

        [Display(Name = "Costo orario")]
        public Money CostoOrario { get; set; }
    }
}