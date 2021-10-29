using System;

namespace App.Models.Exceptions.Application
{
    public class EdificioNotFoundException : Exception
    {
        public EdificioNotFoundException(string idEdificio) : base($"Laboratorio {idEdificio} non trovato")
        {
            IdEdificio = idEdificio;
        }

        public string IdEdificio { get; }
    }
}