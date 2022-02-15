using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DoubleEntry.Domain.Entities;
using FluentAssertions;
using Moq;
using Xunit;

namespace DoubleEntry.UnitTests.Domain
{
    public class AccountTests
    {
        private const decimal GenericAmount = 150.38m;
        private const string GenericString = "xpto";

        [Fact]
        public void GivenRandomData_WhenTryToGetAccountBalance_ShouldReturnAsExpected()
        {
            var entries = BuildEntryList(DateTime.Now, 10, -1000, 1000);
            var expectedResult = entries.Sum(x => x.Amount);

            AssertAccountBalanceValue(entries, expectedResult);
        }

        [Fact]
        public void GivenData_WhenTryToGetAccountBalance_ShouldReturnAsExpected()
        {
            var entries = BuildEntryList(DateTime.Now);
            var expectResult = 0m;

            AssertAccountBalanceValue(entries, expectResult);
        }

        [Fact]
        public void GivenData_WhenTryToGetAccountFormattedBalance_ShouldReturnAsExpected()
        {
            var entries = BuildEntryList(DateTime.Now);
            var expectResult = 0m;

            AssertAccountFormattedBalanceValue(entries, $"{expectResult}");
        }

        [Fact]
        public void GivenPositiveBalanceData_WhenTryToGetAccountFormattedBalance_ShouldReturnAsExpected()
        {
            var entries = BuildEntryList(DateTime.Now, 10, 1, 1000);
            var sum = entries.Sum(x => x.Amount);
            var expectedResult = $"{sum} D";

            AssertAccountFormattedBalanceValue(entries, expectedResult);
        }

        [Fact]
        public void GivenNegativeBalanceData_WhenTryToGetAccountFormattedBalance_ShouldReturnAsExpected()
        {
            var entries = BuildEntryList(DateTime.Now, 10, -1000, -1);
            var sum = entries.Sum(x => x.Amount);
            var expectedResult = $"{-sum} C";

            AssertAccountFormattedBalanceValue(entries, expectedResult);
        }

        [Fact]
        public void GivenValidData_WhenTryToBuildAccount_ShouldReturnAsExpected()
        {
            var entity = new Account(GenericString, GenericString);
            entity.Id.Should().NotBe(Guid.Empty);
            entity.CreatedAt.Date.Should().Be(DateTime.Now.Date);
            entity.Entries.Should().NotBeNull();
            entity.Description.Should().NotBeNullOrEmpty();
            entity.Code.Should().NotBeNullOrEmpty();
        }

        private static void AssertAccountBalanceValue(List<Entry> entries, decimal expectedResult)
        {
            var account = new Account(GenericString, GenericString)
            {
                Entries = entries
            };

            account
                .GetAccountBalance()
                .Should()
                .Be(expectedResult);
        }

        private static void AssertAccountFormattedBalanceValue(List<Entry> entries, string expectedResult)
        {
            var account = new Account(GenericString, GenericString)
            {
                Entries = entries
            };

            account
                .GetFormattedAccountBalance()
                .Should()
                .Be(expectedResult);
        }

        private List<Entry> BuildEntryList(DateTime competenceDate, int entriesCount, int minValue, int maxValue)
        {
            var accountId = Guid.NewGuid();
            var entries = new List<Entry>();
            for (int i = 0; i <= entriesCount - 1; i++)
            {
                var random = new Random();
                var amount = decimal.Parse(random.Next(minValue, maxValue).ToString());
                entries.Add(new Entry(amount)
                {
                    AccountId = accountId,
                    CompetenceDate = competenceDate,
                    Description = GetDescription(amount, i + 1)
                });
            }

            return entries;
        }

        private List<Entry> BuildEntryList(DateTime competenceDate)
        {
            var accountId = Guid.NewGuid();
            var entries = new List<Entry>()
            {
                new Entry(GenericAmount)
                {
                    AccountId = accountId,
                    CompetenceDate = competenceDate,
                    Description = GetDescription(GenericAmount, 1)
                },
                new Entry(-GenericAmount)
                {
                    AccountId = accountId,
                    CompetenceDate = competenceDate,
                    Description = GetDescription(-GenericAmount, 2)
                }
            };

            return entries;
        }

        private static string GetDescription(decimal amount, int index) => $"Entry number {index} of value {amount}";
        
    }
}