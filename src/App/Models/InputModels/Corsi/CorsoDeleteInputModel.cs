using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Corsi
{
    public class CorsoDeleteInputModel
    {
        public int Id { get; set; }

        public string IdCorso { get; set; }
    }
}
