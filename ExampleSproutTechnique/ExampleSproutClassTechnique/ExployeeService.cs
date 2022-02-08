namespace ExampleSproutClassTechnique
{
    public class ExployeeService : IEmployeeService
    {
        public List<Employee> GetEmployeeData()
        {
            var result = new List<Employee>();

            result.Add(new Employee { UniqueId = 1, FirstName = "Jefté", LastName = "Goes" });

            var salaryDataService = new EmployeeSalaryService();
            var salaries = salaryDataService.GetEmployeeData();

            result.ForEach(x =>
            {
                var salaryData = salaries.First(y => y.UniqueId == x.UniqueId);
                x.Salary = salaryData.Salary;
            });

            return result;
        }
    }
}