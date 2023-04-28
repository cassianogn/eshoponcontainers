using Cassiano.EShopOnContainers.Core.Domain.Helpers.Extensions;
using System;
using Xunit;

namespace Cassiano.EShopOnContainers.Core.Domain.Tests.Unit.Tests
{
    public class HelperTests
    {


        [Fact(DisplayName = "String format to search - success")]
        public void Entity_Create_Success()
        {
            var name = "cássiano Garcia nunes";
            var searchableName = "cassiano garcia nunes";

            Assert.Equal(name.ToSerachable(), searchableName);
        }
    }
}
