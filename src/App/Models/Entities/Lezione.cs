using System;
using SequentialGuid;

namespace App.Models.Entities
{
    public partial class Lezione
    {
        public Lezione(int corsoId, string NomeLezione, string CodiceCorso, string CodiceDocente, string CodiceAula, string DataInizioLezione, string DataFineLezione)
        {
            CorsoId = corsoId;
            IdLezione = SequentialGuidGenerator.Instance.NewGuid().ToString();
            ChangeNomeLezione(NomeLezione);
            ChangeCodiceCorso(CodiceCorso);
            ChangeCodiceDocente(CodiceDocente);
            ChangeCodiceAula(CodiceAula);
            ChangeDataInizioLezione(DataInizioLezione);
            ChangeDataFineLezione(DataFineLezione);
            Note = "Dato mancante";
        }

        public int Id { get; set; }
        public int CorsoId { get; set; }
        public int DocenteId { get; set; }
        public string IdLezione { get; set; }
        public string NomeLezione { get; set; }
        public string CodiceCorso { get; set; }
        public string CodiceDocente { get; set; }
        public string CodiceAula { get; set; }
        public string DataInizioLezione { get; set; }
        public string DataFineLezione { get; set; }
        public string Note { get; set; }
        public virtual Corso Corso { get; set; }
        public virtual Docente Docente { get; set; }

        public void ChangeNomeLezione(string newNomeLezione)
        {
            if (string.IsNullOrWhiteSpace(newNomeLezione))
            {
                throw new ArgumentException("La lezione deve avere una descrizione");
            }

            NomeLezione = newNomeLezione;
        }

        public void ChangeCodiceCorso(string newCodiceCorso)
        {
            if (string.IsNullOrWhiteSpace(newCodiceCorso))
            {
                throw new ArgumentException("La lezione deve avere un codice corso");
            }

            CodiceCorso = newCodiceCorso;
        }

        public void ChangeCodiceDocente(string newCodiceDocente)
        {
            if (string.IsNullOrWhiteSpace(newCodiceDocente))
            {
                throw new ArgumentException("La lezione deve avere un codice docente");
            }

            CodiceDocente = newCodiceDocente;
        }

        public void ChangeCodiceAula(string newCodiceAula)
        {
            if (string.IsNullOrWhiteSpace(newCodiceAula))
            {
                throw new ArgumentException("La lezione deve avere un codice aula");
            }

            CodiceAula = newCodiceAula;
        }

        public void ChangeDataInizioLezione(string newDataInizioLezione)
        {
            if (string.IsNullOrWhiteSpace(newDataInizioLezione))
            {
                throw new ArgumentException("La lezione deve avere una data di inizio");
            }

            DataInizioLezione = newDataInizioLezione;
        }

        public void ChangeDataFineLezione(string newDataFineLezione)
        {
            if (string.IsNullOrWhiteSpace(newDataFineLezione))
            {
                throw new ArgumentException("La lezione deve avere una data di fine");
            }

            DataFineLezione = newDataFineLezione;
        }

        public void ChangeNote(string newNote)
        {
            if (string.IsNullOrWhiteSpace(newNote))
            {
                throw new ArgumentException("La lezione deve avere le note");
            }

            Note = newNote;
        }
    }
}