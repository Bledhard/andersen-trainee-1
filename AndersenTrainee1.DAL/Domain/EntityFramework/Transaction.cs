namespace AndersenTrainee1.Domain.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations;

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
