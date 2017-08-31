namespace AndersenTrainee1.Domain.EntityFramework
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Customer : IEntityFramewokBaseEntity
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Column(TypeName = "date")]
        public DateTime BirthDate { get; set; }

        [Required]
        [StringLength(50)]
        public string eMail { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
    }
}
