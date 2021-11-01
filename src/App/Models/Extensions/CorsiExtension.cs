using App.Models.Entities;
using App.Models.InputModels.Corsi;
using App.Models.ViewModels.Corsi;

namespace App.Models.Extensions
{
    public static class CorsiExtension
    {
        public static CorsoViewModel ToCorsoViewModel(this Corso corso)
        {
            return new CorsoViewModel
            {
                Id = corso.Id,
                IdCorso = corso.IdCorso,
                CodiceDipartimento = corso.CodiceDipartimento,
                EdizioneCorso = corso.EdizioneCorso,
                NomeCorso = corso.NomeCorso,
                DataInizioCorso = corso.DataInizioCorso,
                DataFineCorso = corso.DataFineCorso,
                OreCorso = corso.OreCorso,
                Note = corso.Note
            };
        }

        public static CorsoDetailViewModel ToCorsoDetailViewModel(this Corso corso)
        {
            return new CorsoDetailViewModel
            {
                Id = corso.Id,
                IdCorso = corso.IdCorso,
                CodiceDipartimento = corso.CodiceDipartimento,
                EdizioneCorso = corso.EdizioneCorso,
                NomeCorso = corso.NomeCorso,
                DataInizioCorso = corso.DataInizioCorso,
                DataFineCorso = corso.DataFineCorso,
                OreCorso = corso.OreCorso,
                Note = corso.Note
                //TODO:
                //Lezioni = docente.Lezioni
                //    .OrderBy(lezione => lezione.Id)
                //    .ThenBy(lezione => lezione.Id)
                //    .Select(lezione => lezione.ToLezioneViewModel())
                //    .ToList()
            };
        }

        public static CorsoEditInputModel ToCorsoEditInputModel(this Corso corso)
        {
            return new CorsoEditInputModel
            {
                Id = corso.Id,
                IdCorso = corso.IdCorso,
                CodiceDipartimento = corso.CodiceDipartimento,
                EdizioneCorso = corso.EdizioneCorso,
                NomeCorso = corso.NomeCorso,
                DataInizioCorso = corso.DataInizioCorso,
                DataFineCorso = corso.DataFineCorso,
                OreCorso = corso.OreCorso,
                Note = corso.Note
            };
        }
    }
}
