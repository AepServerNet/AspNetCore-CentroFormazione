using App.Models.Entities;
using App.Models.InputModels.Docenti;
using App.Models.ViewModels.Docenti;
using System.Linq;

namespace App.Models.Extensions
{
    public static class DocentiExtension
    {
        public static DocenteViewModel ToDocenteViewModel(this Docente docente)
        {
            return new DocenteViewModel
            {
                Id = docente.Id,
                IdDocente = docente.IdDocente,
                NominativoDocente  = docente.NominativoDocente,
                MateriaInsegnata = docente.MateriaInsegnata,
                Telefono = docente.Telefono,
                Email = docente.Email,
                Residenza = docente.Residenza,
                CostoOrario = docente.CostoOrario
            };
        }

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
                CostoOrario = docente.CostoOrario,
                //TODO:
                //Lezioni = docente.Lezioni
                //    .OrderBy(lezione => lezione.Id)
                //    .ThenBy(lezione => lezione.Id)
                //    .Select(lezione => lezione.ToLezioneViewModel())
                //    .ToList()
            };
        }

        public static DocenteEditInputModel ToDocenteEditInputModel(this Docente docente)
        {
            return new DocenteEditInputModel
            {
                Id = docente.Id,
                IdDocente = docente.IdDocente,
                NominativoDocente  = docente.NominativoDocente,
                MateriaInsegnata = docente.MateriaInsegnata,
                Telefono = docente.Telefono,
                Email = docente.Email,
                Residenza = docente.Residenza,
                CostoOrario = docente.CostoOrario
            };
        }
    }
}