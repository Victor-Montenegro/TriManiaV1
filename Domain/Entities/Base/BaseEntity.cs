using System;

namespace Domain.Entities.Base
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime DeletionDate { get; set; }
    }
}
