
using Microsoft.EntityFrameworkCore;
using System.IO;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InnoTech_Blazor_Training.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpolyeeController : ControllerBase
    {

        List<Empolyee> _empolyees = new();
        private readonly DataContext _dataContext;

        public EmpolyeeController(DataContext DataContext)=> _dataContext = DataContext;
        //private const string empolyeeFilePath = "D:\\Empolyees.json";

        //public EmpolyeeController(DbContext context)
        //{
        //    if (!System.IO.File.Exists(empolyeeFilePath))
        //        System.IO.File.Create(empolyeeFilePath);

        //   string empolyeesContant = System.IO.File.ReadAllText(empolyeeFilePath);

        //    if (string.IsNullOrWhiteSpace(empolyeesContant))
        //    {

        //        _empolyees = InitializeEmpolyee(10);

        //        WriteEmpolyeesToFile();

        //    }
        //    else {
        //        _empolyees = JsonConvert.DeserializeObject<List<Empolyee>>(empolyeesContant);
        //    }

        //}

        //private void WriteEmpolyeesToFile()
        //{
        //    string empolyeesJsonContent = JsonConvert.SerializeObject(_empolyees);
        //    System.IO.File.WriteAllText(empolyeeFilePath, empolyeesJsonContent);
        //}



        //public EmpolyeeController(List<Empolyee> empolyees)
        //{
        //    _empolyees = empolyees;

        //    if (_empolyees.Count <= 1)
        //        InitializeEmpolyee(10);
        //}


        public List<Empolyee> InitializeEmpolyee(int maxEmpolyeeCount)
        {
            List<Empolyee> empolyees = new();
            Thread.Sleep(2 * 1000);
            for (int i = 0; i < maxEmpolyeeCount; i++)
            {
                AddEmpolyee(empolyees, i);
                
            }
            return empolyees;
        }

        public void AddEmpolyee(List<Empolyee> empolyees, int empolyeeOrder)
        {
            empolyees.Add(
                new Empolyee
                {
                    Name = $"Empolyee{empolyeeOrder}",
                    Age = empolyeeOrder,
                    Mobile = $"01224176036{empolyeeOrder}",
                    Telephone = $"{04012323324}{empolyeeOrder}"
                }

                );

        }


       

        // GET: api/<EmpolyeeController>
        [HttpGet]
        public List<Empolyee> Get()=> _dataContext.Empolyees.ToList();

        // GET api/<EmpolyeeController>/5
        [HttpGet("{id}")]
        public  Empolyee Get(Guid id) => _dataContext.Empolyees.FirstOrDefault(e => e.Id == id)??new();

        // POST api/<EmpolyeeController>
        [HttpPost]
        public void Post(Empolyee empolyee)
        {
            if (empolyee == null)
                throw new ArgumentNullException("Empolyee was not supplid in api");
            
            empolyee.Id = Guid.NewGuid();
            empolyee.BirthDay = DateTime.Now.AddYears(-20);

            _dataContext.Empolyees.Add(empolyee);
            _dataContext.SaveChanges();
           // WriteEmpolyeesToFile();

        }

        // PUT api/<EmpolyeeController>/5
        [HttpPut("{id}")]
        public void Put(Empolyee empolyee)
        {
            Empolyee? empolyeeFromDb = _dataContext.Empolyees.FirstOrDefault(e => e.Id == empolyee.Id);
            if (empolyeeFromDb == null)
                throw new ArgumentNullException(nameof(empolyeeFromDb));

            _dataContext.Empolyees.Update(empolyee);
        }

        // DELETE api/<EmpolyeeController>/5
        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            Empolyee empolyeeFromDb = _dataContext.Empolyees.FirstOrDefault(e => e.Id == id);
            if (empolyeeFromDb == null)
                throw new ArgumentNullException(nameof(empolyeeFromDb));

            _dataContext.Empolyees.Remove(empolyeeFromDb);
            _dataContext.SaveChanges();


        }
    }
}
