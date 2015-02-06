namespace HR.Zip.EF
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class HR_Zip : DbContext
    {
        public HR_Zip()
            : base("data source=.;initial catalog=HR_Zip;user id=sa;password=123;MultipleActiveResultSets=True;App=EntityFramework")
        {
        }


        public virtual DbSet<hrlog> hrlog { get; set; }
        public virtual DbSet<user_mstr> user_mstr { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<hrlog>()
                .Property(e => e.u_dec1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<hrlog>()
                .Property(e => e.u_dec2)
                .HasPrecision(18, 0);

            modelBuilder.Entity<user_mstr>()
                .Property(e => e.u_dec1)
                .HasPrecision(18, 0);

            modelBuilder.Entity<user_mstr>()
                .Property(e => e.u_dec2)
                .HasPrecision(18, 0);
        }
    }
}