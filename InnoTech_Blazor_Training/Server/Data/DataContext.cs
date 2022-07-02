namespace InnoTech_Blazor_Training.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Empolyee>(new EmpolyeeConfiguration())
                        .ApplyConfiguration<Student>(new StudentConfiguration());
        }
    }
}
