using System;

namespace App.Models.Exceptions.Application
{
    public class DocenteNotFoundException : Exception
    {
        public DocenteNotFoundException(string idDocente) : base($"Docente {idDocente} non trovato")
        {
            IdDocente = idDocente;
        }

        public string IdDocente { get; }
    }
}