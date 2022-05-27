using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Retail.Customer.Rewards.Data.Entities
{
    public class Customer
    {
        [Column("CustomerId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}
