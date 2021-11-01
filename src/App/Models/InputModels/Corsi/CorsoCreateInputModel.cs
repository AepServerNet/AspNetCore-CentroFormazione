using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Corsi
{
    public class CorsoCreateInputModel
    {
        public string IdCorso { get; set; }

        [Display(Name = "Codice Dipartimento")]
        public string CodiceDipartimento { get; set; }

        [Display(Name = "Nome Corso")]
        public string NomeCorso { get; set; }

        [Display(Name = "Data Inizio Corso")]
        public string DataInizioCorso { get; set; }

        [Display(Name = "Data Fine Corso")]
        public string DataFineCorso { get; set; }
        
        [Display(Name = "Ore Corso")]
        public string OreCorso { get; set; }
    }
}
