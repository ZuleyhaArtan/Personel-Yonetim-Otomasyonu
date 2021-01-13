namespace deneme2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class UserManagementEF : DbContext
    {
        public UserManagementEF()
            : base("name=UserManagementEF")
        {
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Departmant> Departmant { get; set; }
        public virtual DbSet<Personal> Personal { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>()
                .Property(e => e.cityName)
                .IsUnicode(false);

            modelBuilder.Entity<Departmant>()
                .Property(e => e.departmantName)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.personalName)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.personalLastName)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.tcNo)
                .IsUnicode(false);

            modelBuilder.Entity<Personal>()
                .Property(e => e.password)
                .IsUnicode(false);
        }
    }
}
