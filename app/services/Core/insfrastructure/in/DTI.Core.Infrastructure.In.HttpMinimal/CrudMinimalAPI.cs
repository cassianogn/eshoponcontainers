using DTI.Core.Domain.DTOs.Search;
using DTI.Core.Domain.Interfaces.DTOs;
using DTI.Core.Domain.Services.Bus;
using DTI.Core.Domain.Services.Bus.Interfaces;
using DTI.Core.Domain.Services.DomainNotifications;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace DTI.Core.Infrastructure.In.HttpMinimal
{
    public static class CrudMinimalAPI
    {
        private const string ROOT_PATH = "/";

        public static void AddCrudFor<TGetByIdQuery, TGetByIdViewModel, TAddCommand, TUpdateCommand, TDeleteCommand>(this WebApplication app, string baseRoute)
            where TGetByIdQuery : class, IEntityDTO, IAppMessage<TGetByIdViewModel>, new()
            where TAddCommand : class, IEntityDTO, IAppMessage<Guid?>
            where TUpdateCommand : class, IEntityDTO, IAppMessage
            where TDeleteCommand : class, IEntityDTO, IAppMessage, new()
        {
            var baseUrl = ROOT_PATH + baseRoute;
            var url = new
            {
                GetById = baseUrl + "/{id}",
                Add = baseUrl,
                Update = baseUrl + "/{id}",
                Delete = baseUrl + "/{id}"
            };

            app.MapGet(url.GetById, async (Guid id, BusService busService, DomainNotificationService domainNotificationService) =>
            {

                var query = new TGetByIdQuery() { Id = id };
                var queryResult = await busService.SendMessage<TGetByIdQuery, TGetByIdViewModel>(query);
                return MinimalAPIResponse.CareErrors(() => TypedResults.Ok(queryResult.Result), domainNotificationService);
            });

            app.MapPost(url.Add, async (TAddCommand command, BusService busService, DomainNotificationService domainNotificationService) =>
            {

                var commandResult = await busService.SendMessage<TAddCommand, Guid?>(command, BusTransactionType.Infrastructure);
                return MinimalAPIResponse.CareErrors(() => TypedResults.Created($"{baseUrl}/{commandResult.Result!.Value}", new { Id = commandResult.Result!.Value }), domainNotificationService);
            });


            app.MapPut(url.Update, async (Guid id, TUpdateCommand command, BusService busService, DomainNotificationService domainNotificationService) =>
            {
                if (id != command.Id)
                    return TypedResults.BadRequest($"The provided id by URL don't is equal as DTO. the url: {id}, DTO: {command.Id}");

                await busService.SendMessage(command);
                return MinimalAPIResponse.CareErrors(() => TypedResults.NoContent(), domainNotificationService);
            });

            app.MapDelete(url.Delete, async (Guid id, BusService busService, DomainNotificationService domainNotificationService) =>
            {
                var command = new TDeleteCommand() { Id = id };
                await busService.SendMessage(command);
                return MinimalAPIResponse.CareErrors(() => TypedResults.NoContent(), domainNotificationService);
            });

        }

        public static void AddNamedEnityCrudFor<TSearchEntityQuery, TSearchEntityViewModel, TGetByIdQuery, TGetByIdViewModel, TAddCommand, TUpdateCommand, TDeleteCommand>(this WebApplication app, string baseRoute)
            where TSearchEntityQuery : SearchQuery, IAppMessage<IEnumerable<TSearchEntityViewModel>>, new()
            where TGetByIdQuery : class, IEntityDTO, IAppMessage<TGetByIdViewModel>, new()
            where TAddCommand : class, IEntityDTO, IAppMessage<Guid?>
            where TUpdateCommand : class, IEntityDTO, IAppMessage
            where TDeleteCommand : class, IEntityDTO, IAppMessage, new()
        {
            app.MapGet(ROOT_PATH + baseRoute, async (string? searchKey, BusService busService, DomainNotificationService domainNotificationService) =>
            {
                var query = new TSearchEntityQuery() { QueryKey = searchKey ?? ""};
                var queryResult = await busService.SendMessage<TSearchEntityQuery, IEnumerable<TSearchEntityViewModel>>(query, BusTransactionType.Infrastructure);
                return MinimalAPIResponse.CareErrors(() => TypedResults.Ok(queryResult.Result), domainNotificationService);

            });
            AddCrudFor<TGetByIdQuery, TGetByIdViewModel, TAddCommand, TUpdateCommand, TDeleteCommand>(app, baseRoute);
        }

    }
}