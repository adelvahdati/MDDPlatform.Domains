using MDDPlatform.Domains.Core.Events;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Core.Entities
{
    public class Domain : BaseAggregate<Guid>
    {
        private List<DomainModel> _domainModels = new List<DomainModel>();
        public string Name { get; private set; }
        public ProblemDomain ProblemDomain { get; private set; }
        public IReadOnlyList<DomainModel> DomainModels => _domainModels;
        private Domain()
        {

        }
        private Domain(ProblemDomain problemDomain, Guid domainId, string name, List<DomainModel>? domainModels = null)
        {
            ProblemDomain = problemDomain;
            Id = domainId;
            Name = name;
            if (domainModels == null)
                _domainModels = new List<DomainModel>();
            else
                _domainModels = domainModels;
        }
        public static Domain Create(ProblemDomain problemDomain, string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new DomainNameNullException("Domain name should not be null");

            Guid domainId = Guid.NewGuid();
            Domain domain = new Domain(problemDomain,domainId,name);
            domain.AddEvent(new DomainCreated(problemDomain.Id,domainId,name));
            return domain;
        }
        public IActionStatus CreateModel(string name,string tag)
        {
            DomainModel? model;
            var action = DomainModel.Create(name,tag);
            if(action.Status == ActionStatus.Failure)
                return TheAction.Failed(action.Message);
                                    
            try{
                model = action.Result;
            }
            catch(Exception ex)
            {
                return TheAction.Failed(ex.Message);;
            }

            ISet<DomainModel> domainModelSet = new HashSet<DomainModel>(_domainModels);
            if (Equals(model, null))
                return TheAction.Failed("Model Creation failed : model is null");

            if (domainModelSet.Add(model))
            {
                _domainModels.Add(model);
                AddEvent(new ModelCreated(Id,model));
                return TheAction.IsDone("Domain model ctreated");
            }
            return TheAction.Failed("Model Creation failed : model with this name and tag exist");
        }
        public IActionResult<DomainModel> GetModel(string name, string tag)
        {
            try
            {
                var model = _domainModels.Where(dm => dm.Name == name && dm.Tag == tag).FirstOrDefault();

                if (Equals(model, null))
                    return TheAction.Failed<DomainModel>("There is no model");

                return TheAction.IsDone<DomainModel>(model);
            }
            catch (Exception ex)
            {
                return TheAction.Failed<DomainModel>(ex.Message);
            }
        }

        public IActionResult<IList<DomainModel>> GetModel(string name)
        {
            try
            {
                var models = _domainModels.Where(dm => dm.Name==name).ToList();
                if (models.Count == 0)
                    return TheAction.Failed<IList<DomainModel>>("There is no model");

                return TheAction.IsDone<IList<DomainModel>>(models);
            }
            catch (Exception ex)
            {
                return TheAction.Failed<IList<DomainModel>>(ex.Message);
            }
        }

    }
}