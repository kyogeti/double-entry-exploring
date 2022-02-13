using System;
using System.Collections.Generic;
using System.Linq;
using DoubleEntry.Common.Extensions;

namespace DoubleEntry.Domain.Entities
{
    public class Account : BaseEntity
    {
        public string Description { get;}
        public string Code { get;}
        public List<Entry> Entries { get; set; }

        public Account(string description, string code)
        {
            if (description.IsNullOrEmpty() || code.IsNullOrEmpty())
                throw new ArgumentException("Description and Code must be provided");

            Entries = new List<Entry>();
            Description = description;
            Code = code;
        }

        public decimal GetAccountBalance() => Entries.Sum(x => x.Amount);

        public string GetFormattedAccountBalance() => Entries
            .Sum(x => x.Amount)
            .ToAccountingFormat();

    }
}