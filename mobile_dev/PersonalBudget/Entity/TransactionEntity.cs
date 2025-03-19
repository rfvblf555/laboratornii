﻿namespace PersonalBudget.Entity
{
    public class TransactionEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }

        public TransactionEntity(
            string title,
            string description,
            decimal amount)
        {
            Title = title;
            Description = description;
            Amount = amount;
            CreatedAt = DateTime.Now;
        }
    }
}
