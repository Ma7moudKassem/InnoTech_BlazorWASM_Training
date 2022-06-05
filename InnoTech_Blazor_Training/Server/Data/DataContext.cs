

namespace InnoTech_Blazor_Training.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        
        }

        public DbSet<Empolyee> Empolyees { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Student>().ToTable("StudentsTable");
            modelBuilder.Entity<Student>().HasKey(e => e.Id);
            modelBuilder.Entity<Student>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Student>().Property(e => e.GPA).IsRequired();
            modelBuilder.Entity<Student>().Property(e => e.Mobile).HasMaxLength(20);
            modelBuilder.Entity<Student>().Property(e => e.Grade).HasMaxLength(30);

            modelBuilder.Entity<Empolyee>().ToTable("OurEmpoyees");
            modelBuilder.Entity<Empolyee>().Property(e => e.Name).HasMaxLength(50);
            modelBuilder.Entity<Empolyee>().Property(e => e.BirthDay).IsRequired();
            modelBuilder.Entity<Empolyee>().Property(e => e.Mobile).HasMaxLength(20);
            modelBuilder.Entity<Empolyee>().Property(e => e.Telephone).HasMaxLength(20);
            modelBuilder.Entity<Empolyee>().Property(e => e.Name).IsRequired();
            modelBuilder.Entity<Empolyee>().HasKey(e => e.Id);

        }


    }
}
