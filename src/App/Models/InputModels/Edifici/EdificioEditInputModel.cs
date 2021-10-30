using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Edifici
{
    public class EdificioEditInputModel
    {
        public int Id { get; set; }
        
        public string IdEdificio { get; set; }

        [Display(Name = "Codice dipartimento")]
        public string CodiceDipartimento { get; set; }

        [Display(Name ="Aula")]
        public string Aula { get; set; }

        [Display(Name ="Indirizzo")]
        public string Indirizzo { get; set; }

        [Display(Name ="Piano")]
        public string Piano { get; set; }

        [Display(Name ="Metri Quadri")]
        public string Mq { get; set; }

        [Display(Name ="Laboratorio")]
        public string Laboratorio { get; set; }

        [Display(Name ="Posti")]
        public string Posti { get; set; }

        [Display(Name ="Note")]
        public string Note { get; set; }
    }
}