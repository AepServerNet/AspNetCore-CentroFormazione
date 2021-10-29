using System.ComponentModel.DataAnnotations;
namespace App.Models.InputModels.Edifici
{
    public class EdificioCreateInputModel
    {
        public string IdEdificio { get; set; }

        [Required(ErrorMessage = "Il codice è obbligatorio"),
        Display(Name = "Codice dipartimento")]
        public string CodiceDipartimento { get; set; }

        [Required(ErrorMessage = "Nome aula obbligatorio"),
        Display(Name ="Aula")]
        public string Aula { get; set; }

        [Required(ErrorMessage = "Il laboratorio è obbligatorio"),
        Display(Name ="Laboratorio")]
        public string Laboratorio { get; set; }
        
        [Required(ErrorMessage = "Il numero dei posti è obbligatorio"),
        Display(Name ="Posti")]
        public string Posti { get; set; }
    }
}