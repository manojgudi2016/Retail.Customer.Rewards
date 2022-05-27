using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Retail.Customer.Rewards.DTO;

namespace Retail.Customer.Rewards.Services.Interface
{
    public interface IRewardsService
    {
        Task<List<CustomerPurchase>> GetTotalRewardPointsInGivenPeriod(int periodInMonths);

        Task<List<CustomerPurchase>> GetTotalRewardPointsByCustomerInGivenPeriod(Guid customerId, int periodInMonths);
    }
}
