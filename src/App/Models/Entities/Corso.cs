using System;
using System.Collections.Generic;
using SequentialGuid;

namespace App.Models.Entities
{
    public partial class Corso
    {
        public Corso(string CodiceDipartimento, string NomeCorso, string DataInizioCorso, string DataFineCorso, string OreCorso)
        {
            IdCorso = SequentialGuidGenerator.Instance.NewGuid().ToString();
            ChangeCodiceDipartimento(CodiceDipartimento);
            EdizioneCorso = "Dato mancante";
            ChangeNomeCorso(NomeCorso);
            ChangeDataInizioCorso(DataInizioCorso);
            ChangeDataFineCorso(DataFineCorso);
            ChangeOreCorso(OreCorso);
            Note = "Dato mancante";

            Lezioni = new HashSet<Lezione>();
        }

        public int Id { get; set; }
        public string IdCorso { get; set; }
        public string CodiceDipartimento { get; set; }
        public string EdizioneCorso { get; set; }
        public string NomeCorso { get; set; }
        public string DataInizioCorso { get; set; }
        public string DataFineCorso { get; set; }
        public string OreCorso { get; set; }
        public string Note { get; set; }
        public virtual ICollection<Lezione> Lezioni { get; set; }

        public void ChangeCodiceDipartimento(string newCodiceDipartimento)
        {
            if (string.IsNullOrWhiteSpace(newCodiceDipartimento))
            {
                throw new ArgumentException("Il corso deve avere un codice dipartimento");
            }

            CodiceDipartimento = newCodiceDipartimento;
        }

        public void ChangeEdizioneCorso(string newEdizioneCorso)
        {
            if (string.IsNullOrWhiteSpace(newEdizioneCorso))
            {
                throw new ArgumentException("Il corso deve avere l'indicazione dell'edizione");
            }

            EdizioneCorso = newEdizioneCorso;
        }

        public void ChangeNomeCorso(string newNomeCorso)
        {
            if (string.IsNullOrWhiteSpace(newNomeCorso))
            {
                throw new ArgumentException("Il corso deve avere un nome");
            }

            NomeCorso = newNomeCorso;
        }

        public void ChangeDataInizioCorso(string newDataInizioCorso)
        {
            if (string.IsNullOrWhiteSpace(newDataInizioCorso))
            {
                throw new ArgumentException("Il corso deve avere una data di inizio");
            }

            DataInizioCorso = newDataInizioCorso;
        }

        public void ChangeDataFineCorso(string newDataFineCorso)
        {
            if (string.IsNullOrWhiteSpace(newDataFineCorso))
            {
                throw new ArgumentException("Il corso deve avere una data di fine");
            }

            DataFineCorso = newDataFineCorso;
        }

        public void ChangeOreCorso(string newOreCorso)
        {
            if (string.IsNullOrWhiteSpace(newOreCorso))
            {
                throw new ArgumentException("Il corso deve avere un monte ore");
            }

            OreCorso = newOreCorso;
        }

        public void ChangeNote(string newNote)
        {
            if (string.IsNullOrWhiteSpace(newNote))
            {
                throw new ArgumentException("Il corso deve avere le note");
            }

            Note = newNote;
        }
    }
}