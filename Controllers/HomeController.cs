using Microsoft.AspNetCore.Mvc;
using WebLabsProj.Models;

namespace WebLabsProj.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonRepo _repository;
        
        public HomeController(IPersonRepo repo)
        {
            _repository = repo;
        }

        public IActionResult Index()
        {
            if (!_repository.People.Any())
            {
                //Filling in memory DB on first load
                List<Person> peopleArray = Enumerable.Range(1, 6).Select(index => new Person
                {
                    Id = Guid.NewGuid(),
                    EmployeeNumber = index,
                    FirstName = "F" + index.ToString(),
                    Surname = "S" + index.ToString(),
                    DoB = DateOnly.FromDateTime(DateTime.Now.AddMonths(index)),
                    Department = "D" + index.ToString(),
                    Position = "P" + index.ToString()
                }).ToList();
                //Adding second May employee
                peopleArray.Add(new Person
                {
                    Id = Guid.NewGuid(),
                    EmployeeNumber = 7,
                    FirstName = "F7",
                    Surname = "S7",
                    DoB = new DateOnly(1999, 5, 20),
                    Position = "P7"
                });
                _repository.AddRange(peopleArray.ToArray());
                _repository.SaveChanges();
            }
            //Only sending the employees born in May to the view.
            return View(_repository.People.Where(p => p.DoB.HasValue && ((DateOnly)p.DoB).Month == 5).ToArray());
        }

        [HttpGet]
        public IActionResult AddEmp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddEmp(Person p)
        {
            //Check if the Employee Number already exists in the DB
            if (_repository.People.Any(person => person.EmployeeNumber==p.EmployeeNumber))
            {
                // Returns to same page without updating database, Should send bad request and implement handler to inform User.
                return View();
            }
            p.Id = Guid.NewGuid();
            _repository.AddEmp(p);
            _repository.SaveChanges();
            //Returns to same page incase another employee is wanted to be added.
            return View();
        }
    }
}