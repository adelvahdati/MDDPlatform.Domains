using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Repository;
using MDDPlatform.Domains.Infrastructure.Data.Context;
using MDDPlatform.Domains.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace MDDPlatform.Domains.Infrastructure.Data.Repositories
{
    public class DomainReader : IDomainReader
    {
        private readonly ReadContext _dbContext;
        private readonly DbSet<DomainData> _domains;

        public DomainReader(ReadContext dbContext){
            _dbContext = dbContext;
            _domains =dbContext.Domains;
        }
        public async Task<IList<ModelDto>> GetAllModelsAsync(Guid domainId)
        {
            var models = await _domains.Include(d=>d.DomainModels)
                                        .Where(d=>d.Id == domainId)
                                        .SelectMany(d=>d.DomainModels)
                                        .Select(m=> m.ToDto())
                                        .ToListAsync();

            return models;
        }

        public async Task<DomainDto> GetDomain(Guid domainId)
        {
            var domain = await _domains.Include(d=>d.DomainModels)
                                        .Where(d=>d.Id == domainId)
                                        .FirstOrDefaultAsync();
            if(!Equals(domain,null))
                return domain.ToDto();

            return null;
        }

        public async Task<ModelDto> GetModelAsync(Guid domainId, string name, string tag)
        {
            var model = await _domains.Include(d=>d.DomainModels)
                        .Where(d=>d.Id == domainId)
                        .SelectMany(d=>d.DomainModels)
                        .Where(dm=> dm.Name == name && dm.Tag == tag).FirstOrDefaultAsync();
            
            
            if(!Equals(model,null))
                return model.ToDto();

            return null;
        }

        public async Task<IList<ModelDto>> GetModelsByNameAsync(Guid domainId, string name)
        {
            var models = await _domains.Include(d=>d.DomainModels)
                        .Where(d=>d.Id == domainId)
                        .SelectMany(d=>d.DomainModels)
                        .Where(dm=> dm.Name == name)
                        .Select(m=>m.ToDto())
                        .ToListAsync();

            return models;
        }
    }
}