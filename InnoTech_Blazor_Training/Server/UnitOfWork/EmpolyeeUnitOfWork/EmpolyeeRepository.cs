namespace InnoTech_Blazor_Training.Server.UnitOfWork.EmpolyeeUnitOfWork
{
    public class EmpolyeeRepository : BaseRepository<Empolyee>, IEmpolyeeRepository
    {
        public EmpolyeeRepository(DataContext context) : base(context)
        {
        }
    }
}
