using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.Bottle;
using WhiskyMan.Repositories.Helpers;
using WhiskyMan.Repositories.Interfaces;

namespace WhiskyMan.Repositories
{
    public class BottleRepository : IBottleRepository
    {
        private readonly IDataContextWrapper context;
        private readonly IMapper mapper;

        public BottleRepository(
            IDataContextWrapper context,
            IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<long> AddBottle(BottleForAddition bottle)
        {
            var bottleEntity = mapper.Map<Bottle>(bottle);
            await context.AddEntityAsync(bottleEntity);

            bottleEntity.Ownerships = bottle
                .OwnerIds
                .Select(id => new Ownership { OwnerId = id, BottleId = bottleEntity.Id })
                .ToList();

            await context.SaveChangesAsync();

            return bottleEntity.Id;
        }

        public Task<List<BottleView>> GetActiveBottleViews()
            => context.Bottles
                .Where(b => !b.IsDrunk)
                .Include(b => b.Owners)
                .Include(b => b.BottleDescription)
                    .ThenInclude(d => d.Tags)
                .ProjectTo<BottleView>(mapper.ConfigurationProvider)
                .ToListAsync();

        public async Task<BottleForPriceModel> GetBottleForPriceModel(long bottleId)
        {
            var bottleEntity = 
                await context.Bottles
                    .Include(b => b.SpecialPrices)
                    .Include(b => b.Owners)
                    .FirstOrDefaultAsync(b => b.Id == bottleId);

            return bottleEntity is not null ? mapper.Map<BottleForPriceModel>(bottleEntity) : null;
        }   
    }
}
