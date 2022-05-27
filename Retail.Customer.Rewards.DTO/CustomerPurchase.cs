using System;

namespace Retail.Customer.Rewards.DTO
{
    public class CustomerPurchase
    {
        public Guid CustomerId { get; set; }

        public decimal TotalSpent { get; set; }

        public decimal RewardPoints { get; set; }

    }
}
