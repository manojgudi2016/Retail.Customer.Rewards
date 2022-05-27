using Microsoft.VisualStudio.TestTools.UnitTesting;
using Retail.Customer.Rewards.Api.Controllers;
using Moq;
using Retail.Customer.Rewards.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using Retail.Customer.Rewards.Services.Service;
using Retail.Customer.Rewards.Data;
using Microsoft.EntityFrameworkCore;
using System;
using Retail.Customer.Rewards.DTO;

namespace Retail.Customer.Rewards.Test
{
    [TestClass]
    public class RewardsTest
    {

        [TestMethod]
        public void Rewards_GetAll_ReturnCollection()
        {
            //Negative test case
            var nameSpace = typeof(Retail.Customer.Rewards.Api.Startup).Namespace;
            var builder = new DbContextOptionsBuilder<DataContext>().
                UseSqlServer("Server=DESKTOP-442SEHB\\SQLEXPRESS;Database=DefaultDatabase;Integrated Security=SSPI", x => x.MigrationsAssembly(nameSpace));

            using (var ctx = new DataContext(builder.Options))
            {
                IRewardsService rewardService = new RewardsService(ctx);
                var result = rewardService.GetTotalRewardPointsInGivenPeriod(3).GetAwaiter().GetResult()?[0];
                Assert.AreEqual(result, null);

            }
        }

        [TestMethod]
        public void Rewards_GetById_ReturnCustomerRewards_3Month()
        {
            var nameSpace = typeof(Retail.Customer.Rewards.Api.Startup).Namespace;
            var builder = new DbContextOptionsBuilder<DataContext>().
                UseSqlServer("Server=DESKTOP-442SEHB\\SQLEXPRESS;Database=DefaultDatabase;Integrated Security=SSPI", x => x.MigrationsAssembly(nameSpace));

            using (var ctx = new DataContext(builder.Options))
            {
                IRewardsService rewardService = new RewardsService(ctx);
                var result = rewardService.GetTotalRewardPointsByCustomerInGivenPeriod(Guid.Parse("2C2538A5-55F3-4110-562A-08DA3F91A8D6"), 3).GetAwaiter().GetResult()?[0];
                Assert.AreEqual(result.RewardPoints, 5501.98M);
            }
        }

        [TestMethod]
        public void Rewards_GetById_ReturnCustomerRewards_1Month()
        {
            var nameSpace = typeof(Retail.Customer.Rewards.Api.Startup).Namespace;
            var builder = new DbContextOptionsBuilder<DataContext>().
                UseSqlServer("Server=DESKTOP-442SEHB\\SQLEXPRESS;Database=DefaultDatabase;Integrated Security=SSPI", x => x.MigrationsAssembly(nameSpace));

            using (var ctx = new DataContext(builder.Options))
            {
                IRewardsService rewardService = new RewardsService(ctx);
                var result = rewardService.GetTotalRewardPointsByCustomerInGivenPeriod(Guid.Parse("2C2538A5-55F3-4110-562A-08DA3F91A8D6"), 1).GetAwaiter().GetResult()?[0];
                Assert.AreEqual(result.RewardPoints, 1801.98M);
            }
        }
    }
}
