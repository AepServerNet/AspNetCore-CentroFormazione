using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Edifici
{
    public class EdificioDeleteInputModel
    {
        public int Id { get; set; }

        [Required]
        public string IdEdificio { get; set; }
    }
}