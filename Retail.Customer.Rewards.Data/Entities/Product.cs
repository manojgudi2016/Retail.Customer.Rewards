using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Retail.Customer.Rewards.Data.Entities
{
    public class Product
    {
        [Column("ProductId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Category { get; set; }

        public decimal Price { get; set; }

    }
}
