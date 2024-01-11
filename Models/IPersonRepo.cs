namespace WebLabsProj.Models
{
    public interface IPersonRepo
    {
        public IQueryable<Person> People { get; }
        void AddEmp(Person person);
        void AddRange(Person[] people);
        void SaveChanges();
    }
}
