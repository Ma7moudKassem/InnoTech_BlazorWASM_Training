namespace InnoTech_Blazor_Training.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeController : BaseController<Empolyee>
    {
        public EmpolyeeController(IEmpolyeeUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
