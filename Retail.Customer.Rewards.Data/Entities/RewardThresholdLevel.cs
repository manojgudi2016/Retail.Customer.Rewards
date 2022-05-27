using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
namespace Retail.Customer.Rewards.Data.Entities
{
    public class RewardThresholdLevel
    {
        [Column("ThresholdId"), DatabaseGenerated(DatabaseGeneratedOption.Identity), Key]
        public int Id { get; set; }

        public string Level { get; set; }

        public decimal Threshold { get; set; }

        public int RewardPoint { get; set; }

        public bool isActive { get; set; }
    }
}
