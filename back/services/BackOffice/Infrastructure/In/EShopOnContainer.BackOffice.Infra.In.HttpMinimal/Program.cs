
using Cassiano.EShopOnContainers.Core.Infrastructure.In.HttpMinimal;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.AddProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.DeleteProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Commands.UpdateProduct;
using EShopOnContainer.BackOffice.Application.In.Products.Queries.GetProductById;
using EShopOnContainer.BackOffice.Application.In.Products.Queries.SearchProduct;
using EShopOnContainer.BackOffice.Infra.CrossCutting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationWithDependencies(builder.Configuration.GetConnectionString("DefaultConnection")!);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.AddNamedEnityCrudFor<SearchProductQuery, SearchProductViewModel, GetProductByIdQuery, GetProductByIdViewModel, AddProductCommand, UpdateProductCommand, DeleteProductCommand>("product");


app.Run();
