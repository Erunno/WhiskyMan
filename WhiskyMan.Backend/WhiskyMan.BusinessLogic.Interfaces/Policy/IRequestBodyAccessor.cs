using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.BusinessLogic.Interfaces.Policy
{
    public interface IRequestBodyAccessor
    {
        Task<TBody> GetRequestBody<TBody>();
    }
}
