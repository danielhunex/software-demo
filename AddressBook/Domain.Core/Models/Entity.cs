using System;

namespace Domain.Core.Models
{
    public abstract class Entity
    {
        public long Id
        {
            get; set;
        }

        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
