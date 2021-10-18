using System.Threading.Tasks;
using App.Models.Entities;
using App.Models.InputModels.Docenti;
using App.Models.Services.Infrastructure;
using App.Models.ViewModels.Docenti;
using App.Models.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using App.Models.ViewModels;
using System.Linq;
using System.Collections.Generic;
using App.Models.Exceptions.Application;

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

        public async Task<ListViewModel<DocenteViewModel>> GetDocentiAsync(DocenteListInputModel model)
        {
            IQueryable<Docente> baseQuery = dbContext.Docenti;

            baseQuery = (model.OrderBy, model.Ascending) switch
            {
                ("NominativoDocente", true) => baseQuery.OrderBy(docente => docente.NominativoDocente),
                ("NominativoDocente", false) => baseQuery.OrderByDescending(docente => docente.NominativoDocente),
                ("Id", true) => baseQuery.OrderBy(docente => docente.Id),
                ("Id", false) => baseQuery.OrderByDescending(docente => docente.Id),
                _ => baseQuery
            };

            IQueryable<Docente> queryLinq = baseQuery
                .Where(docente => docente.NominativoDocente.Contains(model.Search))
                .AsNoTracking();

            List<DocenteViewModel> docente = await queryLinq
                .Skip(model.Offset)
                .Take(model.Limit)
                .Select(docente => docente.ToDocenteViewModel())
                .ToListAsync();

            int totalCount = await queryLinq.CountAsync();

            ListViewModel<DocenteViewModel> result = new()
            {
                Results = docente,
                TotalCount = totalCount
            };

            return result;
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
            catch (DbUpdateException)
            {
                logger.LogWarning("Errore durante la creazione del docente {NominativoDocente}.", NominativoDocente);
                throw new DatabaseUpdateException(NominativoDocente);
            }

            return docente.ToDocenteDetailViewModel();
        }

        public async Task<DocenteEditInputModel> GetDocenteForEditingAsync(string IdDocente)
        {
            IQueryable<DocenteEditInputModel> queryLinq = dbContext.Docenti
                .AsNoTracking()
                .Where(docente => docente.IdDocente == IdDocente)
                .Select(docente => docente.ToDocenteEditInputModel());

            DocenteEditInputModel viewModel = await queryLinq.FirstOrDefaultAsync();

            if (viewModel == null)
            {
                logger.LogWarning("Docente {IdDocente} non trovato", IdDocente);
                throw new DocenteNotFoundException(IdDocente);
            }

            return viewModel;
        }

        public async Task<DocenteDetailViewModel> EditDocenteAsync(DocenteEditInputModel inputModel)
        {
            int DocenteId = await GetFindIdDocente(inputModel.IdDocente.ToString());

            Docente docente = await dbContext.Docenti.FindAsync(DocenteId);

            if (docente == null)
            {
                logger.LogWarning("Docente {IdDocente} non trovato", inputModel.IdDocente);
                throw new DocenteNotFoundException(inputModel.IdDocente);
            }

            docente.ChangeNominativoDocente(inputModel.NominativoDocente);
            docente.ChangeMateriaInsegnata(inputModel.MateriaInsegnata);
            docente.ChangeTelefono(inputModel.Telefono);
            docente.ChangeEmail(inputModel.Email);
            docente.ChangeResidenza(inputModel.Residenza);

            //TODO: In fase di aggiunta delle dropdownlist per CodiceCorso e CodiceDipartimento, scommentare riga 124 e 125
            //docente.ChangeCodiceCorso(inputModel.CodiceCorso);
            //docente.ChangeCodiceDipartimento(inputModel.CodiceDipartimento);
            docente.ChangeCostoOrario(inputModel.CostoOrario);

            try
            {
                await dbContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                logger.LogWarning("Errore durante l'aggiornamento dei dati del docente {NominativoDocente}.", inputModel.NominativoDocente);
                throw new DatabaseUpdateException(inputModel.NominativoDocente);
            }

            return docente.ToDocenteDetailViewModel();
        }

        public async Task<DocenteDetailViewModel> GetDocenteAsync(string IdDocente)
        {
            IQueryable<DocenteDetailViewModel> queryLinq = dbContext.Docenti
                .AsNoTracking()
                .Where(docente => docente.IdDocente == IdDocente)
                .Select(docente => docente.ToDocenteDetailViewModel());

            DocenteDetailViewModel viewModel = await queryLinq.FirstOrDefaultAsync();

            if (viewModel == null)
            {
                logger.LogWarning("Docente {IdDocente} non trovato", IdDocente);
                throw new DocenteNotFoundException(IdDocente);
            }

            return viewModel;
        }

        public async Task DeleteDocenteAsync(DocenteDeleteInputModel inputModel)
        {
            int DocenteId = await GetFindIdDocente(inputModel.IdDocente.ToString());

            Docente docente = await dbContext.Docenti.FindAsync(DocenteId);

            if (docente == null)
            {
                logger.LogWarning("Docente {IdDocente} non trovato", inputModel.IdDocente);
                throw new DocenteNotFoundException(inputModel.IdDocente);
            }

            dbContext.Remove(docente);
            await dbContext.SaveChangesAsync();
        }

        public async Task<int> GetFindIdDocente(string IdDocente)
        {
            IQueryable<DocenteDetailViewModel> queryLinq = dbContext.Docenti
                .AsNoTracking()
                .Where(docente => docente.IdDocente == IdDocente)
                .Select(docente => docente.ToDocenteDetailViewModel());

            DocenteDetailViewModel viewModel = await queryLinq.FirstOrDefaultAsync();
            
            int IDDocente = viewModel.Id;

            return IDDocente;
        }
    }
}