using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace Retail.Customer.Rewards.Data.Entities
{
    public class Transaction : Trackable
    {
        [Column("TransactionId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public Guid Id { get; set; }

        [JsonIgnore]
        public virtual Retail.Customer.Rewards.Data.Entities.Customer Customer { get; set; }

        public Guid CustomerId { get; set; }


        [JsonIgnore]
        public virtual Retail.Customer.Rewards.Data.Entities.Product Product { get; set; }

        public Guid ProductId { get; set; }
    }
}
