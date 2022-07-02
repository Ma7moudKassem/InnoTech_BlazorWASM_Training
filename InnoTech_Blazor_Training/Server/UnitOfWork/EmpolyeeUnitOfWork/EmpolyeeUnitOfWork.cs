namespace InnoTech_Blazor_Training.Server.UnitOfWork.EmpolyeeUnitOfWork
{
    public class EmpolyeeUnitOfWork : BaseUnitOfWork<Empolyee>, IEmpolyeeUnitOfWork
    {
        public EmpolyeeUnitOfWork(IEmpolyeeRepository repository) : base(repository)
        {
        }
    }
}
