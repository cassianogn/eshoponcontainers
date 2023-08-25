using DTI.Core.Domain.Helpers.Extensions;
using System;
using Xunit;

namespace DTI.Core.Domain.Tests.Unit.FakeEntites
{
    public class HelperTests
    {


        [Trait("Categoria", "Helpers")]
        [Fact(DisplayName = "String format to search - success")]
        public void Entity_Create_Success()
        {
            var name = "cássiano Garcia nunes";
            var searchableName = "cassiano garcia nunes";

            Assert.Equal(name.ToSerachable(), searchableName);
        }
    }
}
