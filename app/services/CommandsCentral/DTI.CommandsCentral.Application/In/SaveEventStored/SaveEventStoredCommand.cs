using DTI.CommandsCentral.Application.In.Base;
using MediatR;

namespace DTI.CommandsCentral.Application.In.SaveEventStored
{
    public class SaveEventStoredCommand : IRequest
    {
        public SaveEventStoredEvent EventStored { get; set; }
    }
}
