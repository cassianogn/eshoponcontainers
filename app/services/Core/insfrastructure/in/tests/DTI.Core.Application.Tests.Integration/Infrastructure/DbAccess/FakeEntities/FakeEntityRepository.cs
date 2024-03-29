﻿using DTI.Core.Application.Tests.Integration.Domain.FakieEntities;
using DTI.Core.Application.Tests.Integration.Infrastructure.DbAccess.DbConnection;
using DTI.Core.Infra.Out.DbAccess.Repository;
using System.Linq;

namespace DTI.Core.Application.Tests.Integration.Infrastructure.DbAccess.FakeEntities
{
    public class FakeEntityRepository : NamedEntityRepository<FakeEntity>, IFakeEntityRepository
    {
        public FakeEntityRepository(TestDb dbContext) : base(dbContext)
        {
        }

    }
}
