using System;
using SequentialGuid;

namespace App.Models.Entities
{
    public partial class Edificio
    {
        public Edificio(string CodiceDipartimento, string Aula, string Laboratorio, string Posti)
        {
            IdEdificio = SequentialGuidGenerator.Instance.NewGuid().ToString();
            ChangeCodiceDipartimento(CodiceDipartimento);
            ChangeAula(Aula);
            Indirizzo = "Dato mancante";
            Piano = "Dato mancante";
            Mq = "Dato mancante";
            ChangeLaboratorio(Laboratorio);
            ChangePosti(Posti);
            Note = "Dato mancante";
        }

        public int Id { get; set; }
        public string IdEdificio { get; set; }
        public string CodiceDipartimento { get; set; }
        public string Aula { get; set; }
        public string Indirizzo { get; set; }
        public string Piano { get; set; }
        public string Mq { get; set; }
        public string Laboratorio { get; set; }
        public string Posti { get; set; }
        public string Note { get; set; }

        public void ChangeCodiceDipartimento(string newCodiceDipartimento)
        {
            if (string.IsNullOrWhiteSpace(newCodiceDipartimento))
            {
                throw new ArgumentException("L'edificio deve avere un codice dipartimento");
            }

            CodiceDipartimento = newCodiceDipartimento;
        }

        public void ChangeAula(string newAula)
        {
            if (string.IsNullOrWhiteSpace(newAula))
            {
                throw new ArgumentException("L'edificio deve avere l'indicazione dell'aula");
            }

            Aula = newAula;
        }

        public void ChangeIndirizzo(string newIndirizzo)
        {
            if (string.IsNullOrWhiteSpace(newIndirizzo))
            {
                throw new ArgumentException("L'edificio deve avere l'indirizzo del laboratorio");
            }

            Indirizzo = newIndirizzo;
        }

        public void ChangePiano(string newPiano)
        {
            if (string.IsNullOrWhiteSpace(newPiano))
            {
                throw new ArgumentException("L'edificio deve avere l'indicazione del piano");
            }

            Piano = newPiano;
        }

        public void ChangeMq(string newMq)
        {
            if (string.IsNullOrWhiteSpace(newMq))
            {
                throw new ArgumentException("L'edificio deve avere l'indicazione dei metri quadri");
            }

            Mq = newMq;
        }

        public void ChangeLaboratorio(string newLaboratorio)
        {
            if (string.IsNullOrWhiteSpace(newLaboratorio))
            {
                throw new ArgumentException("L'edificio deve avere l'indicazione del laboratorio");
            }

            Laboratorio = newLaboratorio;
        }

        public void ChangePosti(string newPosti)
        {
            if (string.IsNullOrWhiteSpace(newPosti))
            {
                throw new ArgumentException("L'edificio deve avere l'indicazione dei posti");
            }

            Posti = newPosti;
        }

        public void ChangeNote(string newNote)
        {
            if (string.IsNullOrWhiteSpace(newNote))
            {
                throw new ArgumentException("L'edificio deve avere le note");
            }

            Note = newNote;
        }
    }
}