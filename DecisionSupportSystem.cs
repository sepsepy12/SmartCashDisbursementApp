using System;
using System.Collections.Generic;

namespace SmartCashDisbursementApp
{
    public class BudgetCategory
    {
        public string Name { get; set; }
        public decimal Allocated { get; set; }
        public decimal Spent { get; set; }
        public decimal Remaining => Allocated - Spent;
    }

    public class SavedGoal
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public decimal TargetAmount { get; set; }
        public DateTime TargetDate { get; set; }
        public decimal CurrentBalance { get; set; }
    }

    public class DecisionSupportSystem
    {
        public Dictionary<string, decimal> AutoAllocate(decimal totalAmount)
        {
            decimal needs = Math.Round(totalAmount * 0.50m, 2);
            decimal wants = Math.Round(totalAmount * 0.30m, 2);
            decimal savings = totalAmount - needs - wants;

            return new Dictionary<string, decimal>
            {
                { "Needs", needs },
                { "Wants", wants },
                { "Savings", savings }
            };
        }

        public bool CanWithdraw(BudgetCategory category, decimal requestedAmount)
        {
            if (requestedAmount <= 0) return false;
            return requestedAmount <= category.Remaining;
        }
    }
}
