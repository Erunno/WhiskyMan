using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhiskyMan.Models.Transaction
{
    public record TransactionForAdditionForRepo
    {
        public long BuyerId { get; set; }
        public long BottleId { get; set; }
        public int Amount_ml { get; set; }
        public decimal Price { get; set; }
    }
}
