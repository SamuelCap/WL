namespace WebLabsProj.Models
{
    public class PersonRepo : IPersonRepo
    {

        private readonly PersonContext _db;

        public PersonRepo(PersonContext db)
        {
            _db = db;
        }
        
        public IQueryable<Person> People => _db.People;

        public void AddRange(Person[] people) => _db.AddRange(people);
        public void AddEmp(Person person) => _db.Add(person);
        public void SaveChanges() => _db.SaveChanges();
    }
}
