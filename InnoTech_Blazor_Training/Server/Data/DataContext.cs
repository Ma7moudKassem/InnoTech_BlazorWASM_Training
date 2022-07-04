namespace InnoTech_Blazor_Training.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmpolyeeConfiguration())
                        .ApplyConfiguration(new StudentConfiguration())
                        .ApplyConfiguration(new ClassRoomConfiguration())
                        .ApplyConfiguration(new ClassRoomStudentConfiguration())
                        .ApplyConfiguration(new SubjectConfiguration())
                        .ApplyConfiguration(new TeacherConfiguration());
        }
    }
}
