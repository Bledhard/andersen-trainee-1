namespace AndersenTrainee1.EntityFramework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Transaction : IEntityFramewokBaseEntity
    {
        public int Id { get; set; }

        public int From { get; set; }

        public int To { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        public int Amount { get; set; }
    }
}
