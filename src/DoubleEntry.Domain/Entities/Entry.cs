using System;

namespace DoubleEntry.Domain.Entities
{
    public enum EntryType
    {
        Debt,
        Credit
    }

    public class Entry : BaseEntity
    {
        public Guid AccountId { get; set; }
        public decimal Amount { get; }
        public EntryType Type { get; }
        public DateTime CompetenceDate { get; set; }
        public string Description { get; set; }

        public Entry(decimal amount)
        {
            if (amount == 0)
                throw new ArgumentException("Value cannot be zero.");

            if (amount > 0)
                Type = EntryType.Debt;

            if (amount < 0)
                Type = EntryType.Credit;

            Amount = amount;
        }
    }
}