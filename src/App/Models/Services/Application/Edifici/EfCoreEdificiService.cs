using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using App.Models.Entities;
using App.Models.Exceptions.Application;
using App.Models.Extensions;
using App.Models.InputModels.Edifici;
using App.Models.Services.Infrastructure;
using App.Models.ViewModels;
using App.Models.ViewModels.Edifici;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace App.Models.Services.Application.Edifici
{
    public class EfCoreEdificiService : IEdificiService
    {
        private readonly ILogger<EfCoreEdificiService> logger;
        private readonly FormazioneDbContext dbContext;

        public EfCoreEdificiService(ILogger<EfCoreEdificiService> logger, FormazioneDbContext dbContext)
        {
            this.logger = logger;
            this.dbContext = dbContext;
        }

        public async Task<ListViewModel<EdificioViewModel>> GetEdificiAsync(EdificioListInputModel model)
        {
            IQueryable<Edificio> baseQuery = dbContext.Edifici;

            baseQuery = (model.OrderBy, model.Ascending) switch
            {
                ("Laboratorio", true) => baseQuery.OrderBy(edificio => edificio.Laboratorio),
                ("Laboratorio", false) => baseQuery.OrderByDescending(edificio => edificio.Laboratorio),
                ("Id", true) => baseQuery.OrderBy(edificio => edificio.Id),
                ("Id", false) => baseQuery.OrderByDescending(edificio => edificio.Id),
                _ => baseQuery
            };

            IQueryable<Edificio> queryLinq = baseQuery
                .Where(edificio => edificio.Laboratorio.Contains(model.Search))
                .AsNoTracking();

            List<EdificioViewModel> edificio = await queryLinq
                .Skip(model.Offset)
                .Take(model.Limit)
                .Select(edificio => edificio.ToEdificioViewModel())
                .ToListAsync();

            int totalCount = await queryLinq.CountAsync();

            ListViewModel<EdificioViewModel> result = new()
            {
                Results = edificio,
                TotalCount = totalCount
            };

            return result;
        }

        public async Task<EdificioDetailViewModel> CreateEdificioAsync(EdificioCreateInputModel inputModel)
        {
            string CodiceDipartimento = inputModel.CodiceDipartimento;
            string Aula = inputModel.Aula;
            string Laboratorio = inputModel.Laboratorio;
            string Posti = inputModel.Posti;
            
            var edificio = new Edificio(CodiceDipartimento, Aula, Laboratorio, Posti);
            dbContext.Add(edificio);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                logger.LogWarning("Errore durante la creazione del laboratorio {Laboratorio}.", Laboratorio);
                throw new DatabaseUpdateException(Laboratorio);
            }

            return edificio.ToEdificioDetailViewModel();
        }

        public async Task<EdificioEditInputModel> GetEdificioForEditingAsync(string IdEdificio)
        {
            IQueryable<EdificioEditInputModel> queryLinq = dbContext.Edifici
                .AsNoTracking()
                .Where(edificio => edificio.IdEdificio == IdEdificio)
                .Select(edificio => edificio.ToEdificioEditInputModel());

            EdificioEditInputModel viewModel = await queryLinq.FirstOrDefaultAsync();

            if (viewModel == null)
            {
                logger.LogWarning("Laboratorio {IdEdificio} non trovato", IdEdificio);
                throw new EdificioNotFoundException(IdEdificio);
            }

            return viewModel;
        }

        public async Task<EdificioDetailViewModel> EditEdificioAsync(EdificioEditInputModel inputModel)
        {
            int EdificioId = await GetFindIdEdificio(inputModel.IdEdificio.ToString());

            Edificio edificio = await dbContext.Edifici.FindAsync(EdificioId);

            if (edificio == null)
            {
                logger.LogWarning("Laboratorio {EdificioId} non trovato", inputModel.IdEdificio);
                throw new DocenteNotFoundException(inputModel.IdEdificio);
            }

            edificio.ChangeCodiceDipartimento(inputModel.CodiceDipartimento);
            edificio.ChangeAula(inputModel.Aula);
            edificio.ChangeIndirizzo(inputModel.Indirizzo);
            edificio.ChangePiano(inputModel.Piano);
            edificio.ChangeMq(inputModel.Mq);
            edificio.ChangeLaboratorio(inputModel.Laboratorio);
            edificio.ChangePosti(inputModel.Posti);
            edificio.ChangeNote(inputModel.Note);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                logger.LogWarning("Errore durante l'aggiornamento dei dati del laboratorio {Laboratorio}.", inputModel.Laboratorio);
                throw new DatabaseUpdateException(inputModel.Laboratorio);
            }

            return edificio.ToEdificioDetailViewModel();
        }

        public async Task<EdificioDetailViewModel> GetEdificioAsync(string IdEdificio)
        {
            IQueryable<EdificioDetailViewModel> queryLinq = dbContext.Edifici
                .AsNoTracking()
                .Where(edificio => edificio.IdEdificio == IdEdificio)
                .Select(edificio => edificio.ToEdificioDetailViewModel());

            EdificioDetailViewModel viewModel = await queryLinq.FirstOrDefaultAsync();

            if (viewModel == null)
            {
                logger.LogWarning("Laboratorio {IdEdificio} non trovato", IdEdificio);
                throw new DocenteNotFoundException(IdEdificio);
            }

            return viewModel;
        }

        public async Task DeleteEdificioAsync(EdificioDeleteInputModel inputModel)
        {
            int EdificioId = await GetFindIdEdificio(inputModel.IdEdificio.ToString());

            Docente edificio = await dbContext.Docenti.FindAsync(EdificioId);

            if (edificio == null)
            {
                logger.LogWarning("Laboratorio {IdEdificio} non trovato", inputModel.IdEdificio);
                throw new EdificioNotFoundException(inputModel.IdEdificio);
            }

            dbContext.Remove(edificio);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetFindIdEdificio(string IdEdificio)
        {
            IQueryable<EdificioDetailViewModel> queryLinq = dbContext.Edifici
                .AsNoTracking()
                .Where(edificio => edificio.IdEdificio == IdEdificio)
                .Select(edificio => edificio.ToEdificioDetailViewModel());

            EdificioDetailViewModel viewModel = await queryLinq.FirstOrDefaultAsync();
            
            int IDEdificio = viewModel.Id;

            return IDEdificio;
        }
    }
}