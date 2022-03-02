using MDDPlatform.DomainModels.Core.Enums;
using MDDPlatform.DomainModels.Core.ValueObjects;
using MDDPlatform.Domains.Core.Events;
using MDDPlatform.Domains.Core.ValueObjects;
using MDDPlatform.SharedKernel.ActionResults;
using MDDPlatform.SharedKernel.Entities;

namespace MDDPlatform.Domains.Core.Entities
{
    public class Domain : BaseAggregate<Guid>
    {
        private List<Model> _models = new List<Model>();

        public string Name { get; private set; }
        public ProblemDomain ProblemDomain { get; private set; }
        public IReadOnlyList<Model> Models => _models;

        private Domain()
        {

        }
        private Domain(ProblemDomain problemDomain, Guid domainId, string name, List<Model>? domainModels = null)
        {
            ProblemDomain = problemDomain;
            Id = domainId;
            Name = name;
            if (domainModels == null)
                _models = new List<Model>();
            else
                _models = domainModels;
        }
        public static Domain Create(ProblemDomain problemDomain, Guid domainId, string name)
        {
            if(string.IsNullOrEmpty(name))
                throw new DomainNameNullException("Domain name should not be null");
            
            Domain domain = new Domain(problemDomain,domainId,name);
            domain.AddEvent(new DomainCreated(problemDomain.Id,domainId,name));
            return domain;
        }
        public IActionStatus CreateModel(string name,string tag,ModelAbstractions abstraction,int level)
        {
            Model? model;
            var action = Model.Create(name,tag,abstraction,level);
            if(action.Status == ActionStatus.Failure)
                return TheAction.Failed(action.Message);
                                    
            try{
                model = action.Result;
            }
            catch(Exception ex)
            {
                return TheAction.Failed(ex.Message);;
            }

            if (Equals(model, null))
                return TheAction.Failed("Model Creation failed : model is null");

            ISet<Model> domainModelSet = new HashSet<Model>(_models);
            if (domainModelSet.Add(model))
            {
                _models.Add(model);
                AddEvent(new ModelCreated(Id,model));
                return TheAction.IsDone("Domain model ctreated");
            }
            return TheAction.Failed("Model Creation failed : model with this name and tag exist");
        }
        public IActionResult<Model> GetModel(string name, string tag, ModelAbstractions abstraction,int level)
        {
            try
            {
                var type = ModelType.Create(abstraction);
                var model = _models.Where(dm => dm.Name == name && 
                                                dm.Tag == tag && 
                                                dm.Type == type && 
                                                dm.Level == level)
                                    .FirstOrDefault();

                if (Equals(model, null))
                    return TheAction.Failed<Model>("There is no model");

                return TheAction.IsDone<Model>(model);
            }
            catch (Exception ex)
            {
                return TheAction.Failed<Model>(ex.Message);
            }
        }

        public IActionResult<IList<Model>> GetModel(string name,ModelAbstractions abstraction,int level)
        {
            try
            {
                var type = ModelType.Create(abstraction);
                var models = _models.Where(dm => dm.Name==name && 
                                                dm.Type == type && 
                                                dm.Level==level)
                                    .ToList();
                if (models.Count == 0)
                    return TheAction.Failed<IList<Model>>("There is no model");

                return TheAction.IsDone<IList<Model>>(models);
            }
            catch (Exception ex)
            {
                return TheAction.Failed<IList<Model>>(ex.Message);
            }
        }

    }
}