using Retail.Customer.Rewards.Data;
using Retail.Customer.Rewards.Data.Entities;
using Retail.Customer.Rewards.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Retail.Customer.Rewards.DTO;


namespace Retail.Customer.Rewards.Services.Service
{
    public class RewardsService : IRewardsService
    {
        private readonly DataContext db;
        public RewardsService(DataContext _db)
        {
            db = _db;
        }

        //CAN re-use the code into common method
        public async Task<List<CustomerPurchase>> GetTotalRewardPointsInGivenPeriod(int periodInMonths)
        {
            try
            {
                var startDate = DateTime.Now.AddMonths(-periodInMonths);
                var currentDate = DateTime.Now;

                #region read thresholds
                var threholds = await db.RewardThresholdLevels.Where(x => x.isActive == true).ToListAsync();
                var rewardLevel1 = threholds.Where(x => x.Level == "Level1").Select(x => x.Threshold).FirstOrDefault();
                var level1RewardPoint = threholds.Where(x => x.Level == "Level1").Select(x => x.RewardPoint).FirstOrDefault();

                var rewardLevel2 = threholds.Where(x => x.Level == "Level2").Select(x => x.Threshold).FirstOrDefault();
                var level2RewardPoint = threholds.Where(x => x.Level == "Level2").Select(x => x.RewardPoint).FirstOrDefault();
                #endregion

                var query = from T in db.Transactions
                            join C in db.Customers on T.CustomerId equals C.Id
                            join P in db.Products on T.ProductId equals P.Id
                            where T.CreatedAt >= startDate && T.CreatedAt < currentDate
                            group P by new
                            {
                                T.CustomerId
                            }
                            into UP
                            select new CustomerPurchase()
                            {
                                CustomerId = UP.Key.CustomerId,
                                TotalSpent = UP.Sum(c => c.Price),
                                RewardPoints = (UP.Sum(c => c.Price) - rewardLevel1) * level1RewardPoint + (UP.Sum(c => c.Price) - rewardLevel2) * level2RewardPoint
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<CustomerPurchase>> GetTotalRewardPointsByCustomerInGivenPeriod(Guid customerId, int periodInMonths)
        {

            try
            {
                var startDate = DateTime.Now.AddMonths(-periodInMonths);
                var currentDate = DateTime.Now;

                #region read thresholds
                var threholds = await db.RewardThresholdLevels.Where(x => x.isActive == true).ToListAsync();
                var rewardLevel1 = threholds.Where(x => x.Level == "Level1").Select(x => x.Threshold).FirstOrDefault();
                var level1RewardPoint = threholds.Where(x => x.Level == "Level1").Select(x => x.RewardPoint).FirstOrDefault();

                var rewardLevel2 = threholds.Where(x => x.Level == "Level2").Select(x => x.Threshold).FirstOrDefault();
                var level2RewardPoint = threholds.Where(x => x.Level == "Level2").Select(x => x.RewardPoint).FirstOrDefault();
                #endregion

                var query = from T in db.Transactions
                            join C in db.Customers on T.CustomerId equals C.Id
                            join P in db.Products on T.ProductId equals P.Id
                            where T.CreatedAt >= startDate && T.CreatedAt < currentDate
                            && T.CustomerId == customerId
                            group P by new
                            {
                                T.CustomerId
                            }
                            into UP
                            select new CustomerPurchase()
                            {
                                CustomerId = UP.Key.CustomerId,
                                TotalSpent = UP.Sum(c => c.Price),
                                RewardPoints = (UP.Sum(c => c.Price) - rewardLevel1) * level1RewardPoint + (UP.Sum(c => c.Price) - rewardLevel2) * level2RewardPoint
                            };

                return await query.ToListAsync();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        

    }
}
