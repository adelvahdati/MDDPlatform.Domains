using MDDPlatform.DataStorage.SQLDB;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Infrastructure.Data.Context;
using MDDPlatform.Domains.Services.Repositories;

namespace MDDPlatform.Domains.Infrastructure.Data.Repositories{
    public class DomainWriter : IDomainWriter    
    {
        private WriteContext _dbContext;
        private SqlDbRepository<Domain,Guid> _repositoy;

        public DomainWriter(WriteContext dbContext){
            _dbContext = dbContext;
            _repositoy = new SqlDbRepository<Domain, Guid>(_dbContext);

        }
        public async Task CreateAsync(Domain domain)
        {
            await _repositoy.AddAsync(domain);
        }

        public async Task<Domain> GetAsync(Guid domainId)
        {
            return await _repositoy.GetAsync(domainId);
        }

        public async Task<bool> IsDomainDefinedAsync(Guid problemDomainId, string name)
        {
            return await _repositoy.ExistsAsync(d=>d.Name == name && d.ProblemDomain.Id == problemDomainId);
        }

        public async Task UpdateAsync(Domain domain)
        {
            await _repositoy.UpdateAsync(domain);
        }
    }
}