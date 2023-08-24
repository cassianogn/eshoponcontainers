using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.SetIsaData
{
    internal class SetIsaDataCommand
    {
        public Guid Id { get; set; }
        public bool IsEnabled { get; set; }
    }
}
