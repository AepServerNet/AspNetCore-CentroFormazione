using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Docenti
{
    public class DocenteDeleteInputModel
    {
        public int Id { get; set; }

        [Required]
        public string IdDocente { get; set; }
    }
}