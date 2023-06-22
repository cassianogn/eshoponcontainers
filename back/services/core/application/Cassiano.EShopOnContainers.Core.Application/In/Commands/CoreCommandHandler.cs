namespace Cassiano.EShopOnContainers.Core.Application.In.Commands
{
    public abstract class CoreCommandHandler<TEntity, TCommand>
    {
        public abstract Task Execute(TCommand command);

        public async Task CoreExecute(TCommand command)
        {
            try
            {
               

            }
            catch (Exception erro)
            {

                throw;
            }

        }
    }
}
