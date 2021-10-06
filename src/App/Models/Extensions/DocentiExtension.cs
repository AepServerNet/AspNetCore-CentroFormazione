using App.Models.Entities;
using App.Models.ViewModels.Docenti;

namespace App.Models.Extensions
{
    public static class DocentiExtension
    {
        public static DocenteDetailViewModel ToDocenteDetailViewModel(this Docente docente)
        {
            return new DocenteDetailViewModel 
            {
                Id = docente.Id,
                IdDocente = docente.IdDocente,
                NominativoDocente  = docente.NominativoDocente,
                MateriaInsegnata = docente.MateriaInsegnata,
                Telefono = docente.Telefono,
                Email = docente.Email,
                Residenza = docente.Residenza,
                CodiceCorso = docente.CodiceCorso,
                CodiceDipartimento = docente.CodiceDipartimento,
                CostoOrario = docente.CostoOrario
            };
        }
    }
}