using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTI.Core.Domain.EventSourcing
{
    public enum EventType
    {
        Query = 0,
        Create = 1,
        Update = 2,
        Delete = 3,
    }
}
