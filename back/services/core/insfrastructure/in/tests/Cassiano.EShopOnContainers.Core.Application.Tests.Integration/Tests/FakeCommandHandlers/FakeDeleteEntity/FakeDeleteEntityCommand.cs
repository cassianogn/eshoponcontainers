﻿using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Domain.Services.Bus.Interfaces;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Tests.FakeCommandHandlers.FakeDeleteEntity
{
    internal class FakeDeleteEntityCommand : EntityDTO, IAppMessage
    {
    }
}
