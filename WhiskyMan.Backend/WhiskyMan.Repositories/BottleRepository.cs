using AutoMapper;
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

        public async Task<int> AddBottle(BottleForAddition bottle)
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
    }
}
