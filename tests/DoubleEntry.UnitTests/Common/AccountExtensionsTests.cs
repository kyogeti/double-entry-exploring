using DoubleEntry.Common.Extensions;
using FluentAssertions;
using Xunit;

namespace DoubleEntry.UnitTests.Common
{
    public class AccountExtensionsTests
    {
        [Theory]
        [InlineData(1, "1 D")]
        [InlineData(0, "0")]
        [InlineData(-1, "1 C")]
        public void GivenValue_OnTryToFormatAsAccountingFormat_ShouldFormatAsExpected(decimal value, string expectedFormat)
        {
            var result = value.ToAccountingFormat();
            result.Should().Be(expectedFormat);
        }
    }
}