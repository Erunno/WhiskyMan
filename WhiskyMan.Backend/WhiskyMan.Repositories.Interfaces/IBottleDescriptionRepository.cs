using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.BottleDescription;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface IBottleDescriptionRepository
    {
        Task<long> AddBottleDescription(BottleDescriptionForAddition bottleDescription);
        Task<List<BottleDescriptionReference>> GetActiveBottleDescriptionsReferences();
        Task<List<TagReference>> GetActiveTagReferences();
    }
}
