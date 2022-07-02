namespace InnoTech_Blazor_Training.Server.UnitOfWork.EmpolyeeUnitOfWork
{
    public class StudentRepository : BaseSettingsRepository<Student>, IStudentRepository
    {
        public StudentRepository(DataContext context) : base(context)
        {
        }
    }
}
