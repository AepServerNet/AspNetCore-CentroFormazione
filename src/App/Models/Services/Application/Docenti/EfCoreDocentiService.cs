using System;
using System.Threading.Tasks;
using App.Models.Entities;
using App.Models.InputModels.Docenti;
using App.Models.Services.Infrastructure;
using App.Models.ViewModels.Docenti;
using Microsoft.Extensions.Logging;

namespace App.Models.Services.Application.Docenti
{
    public class EfCoreDocentiService : IDocentiService
    {
        private readonly ILogger<EfCoreDocentiService> logger;
        private readonly FormazioneDbContext dbContext;

        public EfCoreDocentiService(ILogger<EfCoreDocentiService> logger, FormazioneDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<DocenteDetailViewModel> CreateDocenteAsync(DocenteCreateInputModel inputModel)
        {
            string NominativoDocente = inputModel.NominativoDocente;
            string MateriaInsegnata = inputModel.MateriaInsegnata;

            var docente = new Docente(NominativoDocente, MateriaInsegnata);
            dbContext.Add(docente);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch
            {
                throw new Exception();
            }

            return DocenteDetailViewModel.FromEntity(docente);
        }
    }
}