namespace InnoTech_Blazor_Training.Server.UnitOfWork.StudentUnitOfWork
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context)
        {
        }
    }
}
