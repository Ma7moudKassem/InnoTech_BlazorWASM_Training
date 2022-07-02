namespace InnoTech_Blazor_Training.Server.UnitOfWork.StudentUnitOfWork
{
    public class StudentUnitOfWork : BaseUnitOfWork<Student>, IStudentUnitOfWork
    {
        public StudentUnitOfWork(IStudentRepository repository) : base(repository)
        {
        }
    }
}
