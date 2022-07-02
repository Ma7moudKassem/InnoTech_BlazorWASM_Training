namespace InnoTech_Blazor_Training.Server.UnitOfWork.EmpolyeeUnitOfWork
{
    public class StudentUnitOfWork : BaseSettingeUnitOfWork<Student>, IStudentUnitOfWork
    {
        public StudentUnitOfWork(IStudentRepository repository) : base(repository)
        {
        }
    }
}
