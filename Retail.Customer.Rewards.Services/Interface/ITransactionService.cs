using Retail.Customer.Rewards.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Retail.Customer.Rewards.Services.Interface
{
    public interface ITransactionService
    {
        Task<List<Transaction>> GetTransactionsByCustomer(Guid customerId);

        Task<bool> CreateTransaction(Transaction T);
    }
}
