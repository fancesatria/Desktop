using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace APIlagi.Models
{
    public partial class ModelUser : DbContext
    {
        public ModelUser()
            : base("name=ModelUser")
        {
        }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.name)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.telp)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.photo)
                .IsUnicode(false);
        }
    }
}
