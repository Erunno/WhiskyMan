using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhiskyMan.Entities;
using WhiskyMan.Models.Transaction;

namespace WhiskyMan.Repositories.Mapping
{
    static class TransactionMaps
    {
        public static void CreateMaps(IMapperConfigurationExpression mce)
        {
            mce.CreateMap<TransactionForAdditionDto, TransactionForAdditionForRepo>();
            mce.CreateMap<TransactionForAdditionForRepo, Transaction>();
        }
    }
}
