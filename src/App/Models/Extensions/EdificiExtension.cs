using App.Models.Entities;
using App.Models.InputModels.Edifici;
using App.Models.ViewModels.Edifici;

namespace App.Models.Extensions
{
    public static class EdificiExtension
    {
        public static EdificioViewModel ToEdificioViewModel(this Edificio edificio)
        {
            return new EdificioViewModel
            {
                Id = edificio.Id,
                IdEdificio = edificio.IdEdificio,
                CodiceDipartimento = edificio.CodiceDipartimento,
                Aula = edificio.Aula,
                Indirizzo = edificio.Indirizzo,
                Piano = edificio.Piano,
                Mq = edificio.Mq,
                Laboratorio = edificio.Laboratorio,
                Posti = edificio.Posti,
                Note = edificio.Note
            };
        }

        public static EdificioDetailViewModel ToEdificioDetailViewModel(this Edificio edificio)
        {
            return new EdificioDetailViewModel 
            {
                Id = edificio.Id,
                IdEdificio = edificio.IdEdificio,
                CodiceDipartimento = edificio.CodiceDipartimento,
                Aula = edificio.Aula,
                Indirizzo = edificio.Indirizzo,
                Piano = edificio.Piano,
                Mq = edificio.Mq,
                Laboratorio = edificio.Laboratorio,
                Posti = edificio.Posti,
                Note = edificio.Note
            };
        }

        public static EdificioEditInputModel ToEdificioEditInputModel(this Edificio edificio)
        {
            return new EdificioEditInputModel
            {
                Id = edificio.Id,
                IdEdificio = edificio.IdEdificio,
                CodiceDipartimento = edificio.CodiceDipartimento,
                Aula = edificio.Aula,
                Indirizzo = edificio.Indirizzo,
                Piano = edificio.Piano,
                Mq = edificio.Mq,
                Laboratorio = edificio.Laboratorio,
                Posti = edificio.Posti,
                Note = edificio.Note
            };
        }
    }
}