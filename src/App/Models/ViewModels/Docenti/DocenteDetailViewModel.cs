using App.Models.Entities;
using App.Models.ValueTypes;

namespace App.Models.ViewModels.Docenti
{
    public class DocenteDetailViewModel
    {
        public int Id { get; set; }
        public string IdDocente { get; set; }
        public string NominativoDocente { get; set; }
        public string MateriaInsegnata { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Residenza { get; set; }
        public string CodiceCorso { get; set; }
        public string CodiceDipartimento { get; set; }
        public Money CostoOrario { get; set; }

        public static DocenteDetailViewModel FromEntity(Docente docente)
        {
            return new DocenteDetailViewModel {
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