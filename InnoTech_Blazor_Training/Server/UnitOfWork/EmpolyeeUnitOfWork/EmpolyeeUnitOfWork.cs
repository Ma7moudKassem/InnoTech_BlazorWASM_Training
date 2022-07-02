namespace InnoTech_Blazor_Training.Server.UnitOfWork.EmpolyeeUnitOfWork
{
    public class EmpolyeeUnitOfWork : BaseSettingeUnitOfWork<Empolyee> , IEmpolyeeUnitOfWork
    {
        public EmpolyeeUnitOfWork(IEmpolyeeRepository repository) : base(repository)
        {
        }
    }
}
