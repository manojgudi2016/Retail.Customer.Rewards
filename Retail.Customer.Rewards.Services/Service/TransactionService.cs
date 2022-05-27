using Retail.Customer.Rewards.Data;
using Retail.Customer.Rewards.Data.Entities;
using Retail.Customer.Rewards.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Retail.Customer.Rewards.Services.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly DataContext db;
        public TransactionService(DataContext _db)
        {
            db = _db;
        }

        public async Task<bool> CreateTransaction(Transaction T)
        {
            try
            {
                await db.Transactions.AddAsync(T);
                await db.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
               //Log Ex
                return false;
            }
        }

        public async Task<List<Transaction>> GetTransactionsByCustomer(Guid customerId)
        {
            var result =await db.Transactions.Where(x => x.CustomerId == customerId).ToListAsync();
            return result;
        }
    }
}
