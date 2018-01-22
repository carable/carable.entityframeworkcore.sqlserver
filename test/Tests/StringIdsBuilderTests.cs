using Carable.EntityFrameworkCore.SqlServer;
using Xunit;

namespace Tests
{
    public class StringIdsBuilderTests
    {
        [Fact]
        public void Smoke_test()
        {
            var tvp = new StringIdsBuilder()
                .AddRows(new[] { "alpha", "beta" })
                .CreateParameter("someids");
            Assert.Equal("someids", tvp.ParameterName);
        }
    }
}
