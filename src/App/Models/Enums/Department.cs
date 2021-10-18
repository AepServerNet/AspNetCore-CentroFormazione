using System.ComponentModel.DataAnnotations;

namespace App.Models.Enums
{
    public enum Department
    {
        [Display(Name = "Corso OSA")]
        CORSOOSA,

        [Display(Name = "Cucina")]
        CUCINA,

        [Display(Name = "Pasticcere")]
        PASTICCERE,

        [Display(Name = "Acconciatore Biennio")]
        ACCONCIATORE2,

        [Display(Name = "Acconciatore Terzo Anno")]
        ACCONCIATORE3,

        [Display(Name = "Estetista Biennio")]
        ESTETISTA2,

        [Display(Name = "Estetista Terzo Anno")]
        ESTETISTA3
    }
}