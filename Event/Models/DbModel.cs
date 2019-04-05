namespace Event.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<EventDetail> EventDetails { get; set; }
        public virtual DbSet<MyEvent> MyEvents { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventDetail>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<EventDetail>()
                .HasMany(e => e.MyEvents)
                .WithRequired(e => e.EventDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MyEvent>()
                .Property(e => e.EventTitle)
                .IsUnicode(false);

            modelBuilder.Entity<MyEvent>()
                .Property(e => e.Location)
                .IsUnicode(false);
        }
    }
}
