using System.ComponentModel.DataAnnotations;
namespace App.Models.InputModels.Edifici
{
    public class EdificioCreateInputModel
    {
        public string IdEdificio { get; set; }

        [Display(Name = "Codice dipartimento")]
        public string CodiceDipartimento { get; set; }

        [Display(Name ="Aula")]
        public string Aula { get; set; }

        [Display(Name ="Laboratorio")]
        public string Laboratorio { get; set; }

        [Display(Name ="Posti")]
        public string Posti { get; set; }
    }
}