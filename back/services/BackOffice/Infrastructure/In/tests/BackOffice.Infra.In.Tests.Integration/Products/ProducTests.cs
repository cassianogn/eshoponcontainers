using BackOffice.Infra.In.Tests.Integration.Infrastructure;
using Cassiano.EShopOnContainers.BackOffice.Domain.Products.ValueObjects.DTOs;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.AddProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.Shared;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Categories.Commands.AddCategory;
using EShopOnContainer.BackOffice.Application.In.Products.Contexts.Colors.Commands.AddColor;
using EShopOnContainer.BackOffice.Infra.CrossCutting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopOnContainers.BackOffice.Domain.Products;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Categories;
using ShopOnContainers.BackOffice.Domain.Products.Contexts.Colors;

namespace BackOffice.Infra.In.Tests.Integration.Products
{
    //[TestCaseOrderer("Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.TestsConfig.Orders.PriorityOrderer", "Cassiano.EShopOnContainers.Core.Application.Tests.Integration")]
    [Collection(nameof(ProductHandlerCollection))]
    public class ProducTests
    {
        private readonly BusService _bus;
        private readonly ProductHandlerFixture _fixture;
        private readonly IProductRepository _repository;
        private readonly ServiceProvider _serviceProvider;

        public ProducTests(ProductHandlerFixture fixture)
        {
            _fixture = fixture;

            _serviceProvider = new TestServiceProvider().ServiceProvider;
            _bus = _serviceProvider.GetRequiredService<BusService>();
            _repository = _serviceProvider.GetRequiredService<IProductRepository>();
        }

        [Trait("Category", "3 - BackOffice.Product")]
        [Fact(DisplayName = "1 - AddProduct Success")]
        public async Task CreateEntityComandHandler_NewEntity_Success()
        {

            await ConfigureTestDataEnvironmentAsync();
            var categoriesCommands = GetDefaultCategories().ToList();
            var addCategory1Command = categoriesCommands[0];
            var addCategory2Command = categoriesCommands[1];

            var colorsCommands = GetDefaultColors().ToList();
            var addColor1Command = colorsCommands[0];
            var addColor2Command = colorsCommands[1];

            var command = new AddProductCommand()
            {
                Id = Guid.NewGuid(),
                Name = "test",
                Description = "test",
                Enable = true,
                Price = new ProductPriceDTO() { Cost = 10, Sale = 20 },
                ProductCategories = new List<EntityDTO>() { new EntityDTO() { Id = addCategory1Command.Id }, new EntityDTO() { Id = addCategory2Command.Id } },
                ProductColors = new List<ProductColorDTO>() { new ProductColorDTO() { Id = addColor1Command.Id, StockQuantity = 5 }, new ProductColorDTO() { Id = addColor2Command.Id, StockQuantity = 10 } }
            };

            var commandResult = await _bus.SendMessage<AddProductCommand, Guid?>(command);
            Assert.NotNull(commandResult.Result);
            Assert.NotEqual(Guid.Empty, commandResult.Result);

            var addedEntity = await _repository.GetByIdAsync(commandResult.Result!.Value);

            //compara se as propriedades do command são iguais ao do objeto adicionado
            Assert.Equal(command.Id, addedEntity!.Id);
            Assert.Equal(command.Name, addedEntity.Name.Value);
            Assert.Equal(command.Description, addedEntity.Description);
            Assert.Equal(command.Enable, addedEntity.Enable);
            Assert.Equal(command.Price.Cost, addedEntity.Price.Cost);
            Assert.Equal(command.Price.Sale, addedEntity.Price.Sale);

            Assert.Equal(command.ProductCategories.Count, addedEntity.ProductCategories.Count);
            Assert.Collection(command.ProductCategories, pc => Assert.Equal(pc.Id, addedEntity.ProductCategories.ToList()[0].CategoryId),
                                                         pc => Assert.Equal(pc.Id, addedEntity.ProductCategories.ToList()[1].CategoryId));

            Assert.Equal(command.ProductColors.Count, addedEntity.ProductColors.Count);
            Assert.Collection(command.ProductColors, pc => Assert.Equal(pc.Id, addedEntity.ProductColors.ToList()[0].ColorId),
                                                     pc => Assert.Equal(pc.Id, addedEntity.ProductColors.ToList()[1].ColorId));

            _fixture.AddProduct(addedEntity!);

        }
        private IReadOnlyCollection<AddColorCommand> GetDefaultColors()
        {

            var addColor1Command = new AddColorCommand()
            {
                Id = new Guid("18b71e22-53bb-4645-a28d-b913d816dd61"),
                Name = "test color - red",
            };
            var addColor2Command = new AddColorCommand()
            {
                Id = new Guid("877e4e8e-675a-4d5e-85c8-07929a90431d"),
                Name = "test color - blue",
            };
            var addColor3Command = new AddColorCommand()
            {
                Id = new Guid("ffa03612-5a22-4f45-a5db-5540deb75623"),
                Name = "test color - black",
            };
            var comands = new List<AddColorCommand>() { addColor1Command, addColor2Command, addColor3Command };
            return comands;
        }
        private IReadOnlyCollection<AddCategoryCommand> GetDefaultCategories()
        {
            var addCategory1Command = new AddCategoryCommand()
            {
                Id = new Guid("be4c77e3-a9e7-41b6-a764-a30454c7ed44"),
                Name = "test category 1",
            };
            var addCategory2Command = new AddCategoryCommand()
            {
                Id = new Guid("ee4c29df-1876-4052-8256-77d1e0f2d714"),
                Name = "test category 2"
            };
            var addCategory3Command = new AddCategoryCommand()
            {
                Id = new Guid("5eb60839-6f37-44cc-9c0a-f0e9fda1298a"),
                Name = "test category 3",
            };
            var addCategory4Command = new AddCategoryCommand()
            {
                Id = new Guid("72922f92-c546-4c71-9bf7-6fa3553ddf1d"),
                Name = "test category 4",
            };
            var comands = new List<AddCategoryCommand>() { addCategory1Command, addCategory2Command, addCategory3Command, addCategory4Command };
            return comands;
        }
        private async Task ConfigureTestDataEnvironmentAsync()
        {
            var colorRepository = _serviceProvider.GetRequiredService<IColorRepository>();
            var categoryRepository = _serviceProvider.GetRequiredService<ICategoryRepository>();

            var hasColors = colorRepository.SearchByKeywordAsync().Result.Any();
            var hasCategories = categoryRepository.SearchByKeywordAsync().Result.Any();

            if (!hasColors)
            {
                foreach (var color in GetDefaultColors())
                {
                    await _bus.SendMessage<AddColorCommand, Guid?>(color);
                }
            }

            if (!hasCategories)
            {
                foreach (var category in GetDefaultCategories())
                {
                    await _bus.SendMessage<AddCategoryCommand, Guid?>(category);
                }
            }
        }
    }
}
