namespace ExampleSproutClassTechnique
{
    public class EmployeeSalaryService : IEmployeeService
    {
        public List<Employee> GetEmployeeData()
        {
            return new List<Employee>() { new Employee { UniqueId = 1, Salary = 100 } };
        }
    }
}