namespace InnoTech_Blazor_Training.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly DataContext _context;
        public StudentsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<Student> Get() => _context.Students.ToList();

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public Student Get(Guid id) => _context.Students.FirstOrDefault(e => e.Id == id)??new();

        // POST api/<StudentsController>
        [HttpPost]
        public void Post(Student student)
        {
            if (student == null)
                throw new ArgumentNullException("Student is not in Api");

            student.Id = Guid.NewGuid();
            _context.Students.Add(student);
            _context.SaveChanges();
        
        }
        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(Student student)
        {
            Student? studentFromDataBase = _context.Students.FirstOrDefault(e => e.Id == student.Id);
            if (studentFromDataBase == null)
                throw new ArgumentNullException(nameof(studentFromDataBase));

            _context.Students.Update(student);
           
            
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Student? studentFromDataBase = _context.Students.FirstOrDefault(e => e.Id == id);
            if (studentFromDataBase == null)
                throw new ArgumentNullException(nameof(studentFromDataBase));

            _context.Students.Remove(studentFromDataBase);
            _context.SaveChanges();

        }
    }
}
