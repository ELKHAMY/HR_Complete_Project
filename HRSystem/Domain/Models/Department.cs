namespace Domain.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<EmployeePersonalData> Employees { get; set; }
    }
}
