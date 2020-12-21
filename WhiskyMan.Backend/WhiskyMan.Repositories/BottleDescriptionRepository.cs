using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.BottleDescription;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.Repositories
{
    public class BottleDescriptionRepository : IBottleDescriptionRepository
    {
        private readonly IDataContextWrapper dataContext;
        private readonly IMapper mapper;

        public BottleDescriptionRepository(
            IDataContextWrapper dataContext,
            IMapper mapper)
        {
            this.dataContext = dataContext;
            this.mapper = mapper;
        }

        public async Task<int> AddBottleDescription(BottleDescriptionForAddition bottleDescription)
        {
            var descriptionEntity = mapper.Map<BottleDescription>(bottleDescription);
            var createdEntity = await dataContext.AddEntityAsync(descriptionEntity);
            await dataContext.SaveChangesAsync();

            return createdEntity.Entity.Id;
        }
    }
}
