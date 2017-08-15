namespace AndersenTrainee1.EntityFramework
{
    using System;
    using System.Data.Entity;
    using AndersenTrainee1.EntityFramework.Entities;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Container : DbContext
    {
        public Container()
            : base("name=Container")
        {
        }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Wallet> Wallets { get; set; }
        public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Surname)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.eMail)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<Transaction>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Wallet>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.fn)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.fs)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.tn)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.ts)
                .IsUnicode(false);

            modelBuilder.Entity<TransactionLog>()
                .Property(e => e.Currency)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
