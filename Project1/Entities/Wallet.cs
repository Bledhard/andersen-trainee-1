namespace AndersenTrainee1.EntityFramework.Entities
{
    using System.ComponentModel.DataAnnotations;

    public partial class Wallet : IEntityFramewokBaseEntity
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        public bool Status { get; set; }

        [Required]
        [StringLength(3)]
        public string Currency { get; set; }

        public int Amount { get; set; }
    }
}
