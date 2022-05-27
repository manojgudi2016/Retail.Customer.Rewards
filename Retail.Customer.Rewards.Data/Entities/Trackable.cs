using System;
using System.Collections.Generic;
using System.Text;

namespace Retail.Customer.Rewards.Data.Entities
{
    public abstract class Trackable
    {
        public DateTime CreatedAt { get; set; }
        public DateTime ModifiedAt { get; set; }

        public string CreatedBy { get; set; }
        public string ModifieddBy { get; set; }

        public void Created(string createdBy)
        {
            CreatedBy = createdBy;
            CreatedAt = DateTime.UtcNow;
        }

        public void Modified(string modifiedBy)
        {
            ModifieddBy = modifiedBy;
            ModifiedAt = DateTime.UtcNow;
        }
    }
}
