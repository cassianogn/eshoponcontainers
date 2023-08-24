using Cassiano.EShopOnContainers.BackOffice.Domain.Products;
using ShopOnContainers.BackOffice.Domain.Products.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShopOnContainer.BackOffice.Application.In.Products.Commands.SetIsaData
{
    internal class SetIsaDataCommandHandler
    {
        public void Hanlder(SetIsaDataCommand command)
        { 
            Product product = _productRepository.GetById(command.Id);
            SetEnabledProductPolicy.SetAsEnable(product, command.IsEnabled);
            _productRepository.Save(product);
        }
    }
}
