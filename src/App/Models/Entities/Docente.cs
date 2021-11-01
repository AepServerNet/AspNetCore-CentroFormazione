using System;
using System.Collections.Generic;
using App.Models.Enums;
using App.Models.ValueTypes;
using SequentialGuid;

namespace App.Models.Entities
{
    public partial class Docente
    {
        public Docente(string NominativoDocente, string MateriaInsegnata)
        {
            IdDocente = SequentialGuidGenerator.Instance.NewGuid().ToString();
            ChangeNominativoDocente(NominativoDocente);
            ChangeMateriaInsegnata(MateriaInsegnata);
            Telefono = "Dato mancante";
            Email = "Dato mancante";
            Residenza = "Dato mancante";
            CostoOrario = new Money(Currency.EUR, 0);

            Lezioni = new HashSet<Lezione>();
        }

        public int Id { get; set; }
        public string IdDocente { get; set; }
        public string NominativoDocente { get; set; }
        public string MateriaInsegnata { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public string Residenza { get; set; }
        public Money CostoOrario { get; set; }
        public virtual ICollection<Lezione> Lezioni { get; set; }

        public void ChangeNominativoDocente(string newNominativoDocente)
        {
            if (string.IsNullOrWhiteSpace(newNominativoDocente))
            {
                throw new ArgumentException("Il docente deve avere un nominativo");
            }

            NominativoDocente = newNominativoDocente;
        }

        public void ChangeMateriaInsegnata(string newMateriaInsegnata)
        {
            if (string.IsNullOrWhiteSpace(newMateriaInsegnata))
            {
                throw new ArgumentException("Il docente deve avere una materia di insegnamento");
            }

            MateriaInsegnata = newMateriaInsegnata;
        }

        public void ChangeTelefono(string newTelefono)
        {
            if (string.IsNullOrWhiteSpace(newTelefono))
            {
                throw new ArgumentException("Il docente deve avere una materia di insegnamento");
            }

            Telefono = newTelefono;
        }

        public void ChangeEmail(string newEmail)
        {
            if (string.IsNullOrEmpty(newEmail))
            {
                throw new ArgumentException("Il docente deve avere un indirizzo email");
            }

            Email = newEmail;
        }

        public void ChangeResidenza(string newResidenza)
        {
            if (string.IsNullOrEmpty(newResidenza))
            {
                throw new ArgumentException("Il docente deve avere una residenza");
            }

            Residenza = newResidenza;
        }

        public void ChangeCostoOrario(Money newCostoOrario)
        {
            CostoOrario = newCostoOrario;
        }
    }
}