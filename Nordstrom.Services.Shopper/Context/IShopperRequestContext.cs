using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nordstrom.Services.Shopper.Context
{
    public interface IShopperRequestContext
    {
        double Version
        {
            get;
            set;
        }

        Guid CorrelationId
        {
            get;
            set;
        }
    }
}
