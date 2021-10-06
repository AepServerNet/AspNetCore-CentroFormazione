using System.ComponentModel.DataAnnotations;

namespace App.Models.InputModels.Docenti
{
    public class DocenteDeleteInputModel
    {
        [Required]
        public int Id { get; set; }
        public string IdDocente { get; set; }
        
    }
}