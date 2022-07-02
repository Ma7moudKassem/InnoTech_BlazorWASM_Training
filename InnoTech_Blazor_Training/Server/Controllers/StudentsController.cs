namespace InnoTech_Blazor_Training.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : BaseController<Student>
    {
        public StudentController(IStudentUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
