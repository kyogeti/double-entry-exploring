using System;
using DoubleEntry.Domain.Entities;
using FluentAssertions;
using Xunit;

namespace DoubleEntry.UnitTests.Domain
{
    public class BaseEntityTests
    {
        [Fact]
        public void GivenValidData_WhenTryToBuildBaseEntity_ShouldReturnAsExpected()
        {
            var entity = new BaseEntity();
            entity.Id.Should().NotBe(Guid.Empty);
            entity.CreatedAt.Date.Should().Be(DateTime.Now.Date);
        }
    }
}