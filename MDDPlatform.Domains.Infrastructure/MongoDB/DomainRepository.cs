using MDDPlatform.DataStorage.MongoDB.Repositories;
using MDDPlatform.Domains.Application.DTO;
using MDDPlatform.Domains.Application.Interfaces;
using MDDPlatform.Domains.Application.Queries;
using MDDPlatform.Domains.Core.Entities;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.Domains.Infrastructure.MongoDB.Models;
using MDDPlatform.Domains.Services.Repositories;

namespace MDDPlatform.Domains.Infrastructure.MongoDB;
public class DomainRepository : IDomainRepository, IDomainModelDataReader
{
    private IMongoRepository<DomainDocument, Guid> _domainRepository;

    public DomainRepository(IMongoRepository<DomainDocument, Guid> domainRepository)
    {
        _domainRepository = domainRepository;
    }

    public async Task CreateAsync(Domain domain)
    {
        DomainDocument domainDocument = DomainDocument.CreateFrom(domain);
        await _domainRepository.AddAsync(domainDocument);
    }

    public Task<bool> IsDomainDefinedAsync(Guid problemDomainId, string name)
    {
        return _domainRepository.ExistsAsync(domainDocument => domainDocument.ProblemDomainId == problemDomainId && domainDocument.Name == name);
    }

    public async Task UpdateAsync(Domain domain)
    {
        DomainDocument domainDocument = DomainDocument.CreateFrom(domain);
        await _domainRepository.UpdateAsync(domainDocument);
    }
    public async Task<Domain?> GetAsync(Guid domainId)
    {
        var domaindocument = await _domainRepository.GetAsync(domainId);
        if (Equals(domaindocument, null))
            return null;

        return domaindocument.ToDomain();
    }

    public async Task<List<Model>> GetModelsAsync(Guid domainId)
    {
        var domaindocument = await _domainRepository.GetAsync(domainId);
        if (Equals(domaindocument, null))
            return new List<Model>();

        var models = domaindocument.Models.ToList();
        return models.Select(modelDocument => modelDocument.ToModel())
                        .ToList();
    }

    public async Task<List<Model>> GetModelsAsync(Guid domainId, Func<Model, bool> predicate)
    {
        var domaindocument = await _domainRepository.GetAsync(domainId);
        if (Equals(domaindocument, null))
            return new List<Model>();

        var models = domaindocument.Models.ToList();
        return models.Select(modelDocument => modelDocument.ToModel())
                        .Where(model => predicate(model))
                        .ToList();
    }

    public async Task<List<Model>> GetProblemDomainModelsAsync(Guid problemDomainId)
    {
        var domainsDocs = await _domainRepository.ListAsync(domainDoc => domainDoc.ProblemDomainId == problemDomainId);
        if (Equals(domainsDocs, null))
            return new();

        var modelsDocs = domainsDocs.SelectMany(domainDoc => domainDoc.Models).ToList();
        if (modelsDocs == null)
            return new();

        return modelsDocs.Select(modelDoc => modelDoc.ToModel()).ToList();

    }

    public async Task<List<ModelDto>> FindModelsAsync(FindModels query)
    {
        var queryableCollection = _domainRepository.GetQueryableCollection();
        if (query.FilterByProblemDomain.IsApplied)
            queryableCollection = queryableCollection.Where(domain => domain.ProblemDomainId == query.FilterByProblemDomain.Value);


        if (query.FilterByDomain.IsApplied)
            queryableCollection = queryableCollection.Where(domain => domain.Id == query.FilterByDomain.Value);


        var queryableModels = queryableCollection.SelectMany(d => d.Models);

        if (query.FilterByName.IsApplied && !string.IsNullOrEmpty(query.FilterByName.Value))
            queryableModels = queryableModels.Where(m => m.Name.ToLower().Contains(query.FilterByName.Value.ToLower()));


        if (query.FilterByTag.IsApplied && !string.IsNullOrEmpty(query.FilterByTag.Value))
            queryableModels = queryableModels.Where(m => m.Tag.ToLower().Contains(query.FilterByTag.Value.ToLower()));


        if (query.FilterByAbstractionLevel.IsApplied && !string.IsNullOrEmpty(query.FilterByAbstractionLevel.Value))
            queryableModels = queryableModels.Where(m => m.Type.ToLower().Contains(query.FilterByAbstractionLevel.Value.ToLower()));


        if (query.FilterByLnaguage.IsApplied)
            queryableModels = queryableModels.Where(m => m.LanguageId == query.FilterByLnaguage.Value);
        
        return queryableModels.ToList()
                        .Select(model => model.ToDto())
                        .ToList();
    }

    public Task<DomainModelDto?> FindDomainModelAsync(Guid modelId)
    {
        var queryableCollection = _domainRepository.GetQueryableCollection();
        var domainModelDto = queryableCollection.ToList().SelectMany
                                        (
                                            domain=>
                                                domain.Models
                                                .Where(model=>model.Id==modelId)
                                                .Select(model=> new DomainModelDto(model.Id,model.Name,model.Tag,model.Type,model.Level,domain.Id,LanguageDto.CreateFrom(new Language(model.LanguageId,model.LanguageName))))
                                        ).FirstOrDefault();
        return Task.FromResult<DomainModelDto?>(domainModelDto);
    }

    public Task<List<DomainModelDto>?> FindDomainModelsAsync(List<Guid> modelIds)
    {
        var queryableCollection = _domainRepository.GetQueryableCollection();
        var domainModelDtos = queryableCollection.ToList().SelectMany
                                        (
                                            domain=>
                                                domain.Models
                                                .Where(model=>modelIds.Contains(model.Id))
                                                .Select(model=> new DomainModelDto(model.Id,model.Name,model.Tag,model.Type,model.Level,domain.Id,LanguageDto.CreateFrom(new Language(model.LanguageId,model.LanguageName))))
                                        ).ToList();
        return Task.FromResult<List<DomainModelDto>?>(domainModelDtos);
    }

    public async Task DeleteAsync(Domain domain)
    {
        await _domainRepository.DeleteAsync(domain.Id);
    }
}