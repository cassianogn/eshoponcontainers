﻿namespace DTI.Core.Domain.Interfaces.Entities
{
    public  interface IEntity
    {
        Guid Id { get; }
        bool Deleted { get; }

        void SetAsDeleted();
    }
}
