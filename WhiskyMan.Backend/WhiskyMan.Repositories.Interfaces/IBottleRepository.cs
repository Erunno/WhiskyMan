using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Models.Bottle;

namespace WhiskyMan.Repositories.Interfaces
{
    public interface IBottleRepository
    {
        Task<int> AddBottle(BottleForAddition bottle);
    }
}
