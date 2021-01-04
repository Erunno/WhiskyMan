using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
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
            descriptionEntity.Tags = await dataContext.Tags
                .Where(tag => bottleDescription.TagIds.Contains(tag.Id))
                .ToListAsync();

            var createdEntity = await dataContext.AddEntityAsync(descriptionEntity);
            await dataContext.SaveChangesAsync();

            return createdEntity.Entity.Id;
        }

        public Task<List<BottleDescriptionReference>> GetActiveBottleDescriptionsReferences()
            => dataContext.BottleDescriptions
                .Where(des => des.Active)
                .ProjectTo<BottleDescriptionReference>(mapper.ConfigurationProvider)
                .ToListAsync();

        public Task<List<TagReference>> GetActiveTagReferences()
            => dataContext.Tags
                .Where(tag => tag.Active)
                .ProjectTo<TagReference>(mapper.ConfigurationProvider)
                .ToListAsync();
    }
}
