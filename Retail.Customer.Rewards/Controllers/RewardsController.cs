using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Retail.Customer.Rewards.Services.Interface;
using Retail.Customer.Rewards.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Retail.Customer.Rewards.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardsController : ControllerBase
    {

        private readonly IRewardsService rs;

        public RewardsController(IRewardsService _rs)
        {
            rs = _rs;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        // GET: api/<RewardsController>
        [HttpGet("get-all")]
        public Task<List<CustomerPurchase>> GetAll(int period)
        {
            //For single month pass period =1, for 3 months pass 3
            return rs.GetTotalRewardPointsInGivenPeriod(period);
        }

        // GET api/<RewardsController>/5
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        [HttpGet("get-byid")]
        public Task<List<CustomerPurchase>> GetById(Guid id,int period)
        {
            return rs.GetTotalRewardPointsByCustomerInGivenPeriod(id, period);
        }

        // POST api/<RewardsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RewardsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RewardsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
