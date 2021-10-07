using System;

namespace App.Models.Exceptions.Application
{
    public class DatabaseUpdateException : Exception
    {
        public DatabaseUpdateException(string nominativoDocente) : base($"Errore durante la creazione del docente {nominativoDocente}")
        {
            NominativoDocente = nominativoDocente;
        }

        public string NominativoDocente { get; }
    }
}