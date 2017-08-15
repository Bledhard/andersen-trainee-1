namespace AndersenTrainee1.EntityFramework.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TransactionLog")]
    public partial class TransactionLog : IEntityFramewokBaseEntity
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string fn { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string fs { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(50)]
        public string tn { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string ts { get; set; }

        [Key]
        [Column(Order = 4)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Amount { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(3)]
        public string Currency { get; set; }

        [Key]
        [Column(Order = 6)]
        public DateTime Date { get; set; }
    }
}
