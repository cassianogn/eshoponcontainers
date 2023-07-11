using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Domain.FakieEntities;
using Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using Cassiano.EShopOnContainers.Core.Domain.DTOs.Entities;
using Cassiano.EShopOnContainers.Core.Infrastructure.Out.DbAccess.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Cassiano.EShopOnContainers.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities
{
    public class FakeEntityRepository : NamedEntityRepository<FakeEntity>, IFakeEntityRepository
    {
        public FakeEntityRepository(TestDb dbContext) : base(dbContext)
        {
        }
    }
}
