using System.Collections.Generic;
using Moq;
using Xunit;

namespace ExampleSproutClassTechnique.Tests;

public class EmployeeTests
{
    [Fact]
    public void GetEmplyeeData_ReturnsSalaries()
    {
        var currentDataObject = new Mock<IEmployeeService>();
        currentDataObject
            .Setup(x => x.GetEmployeeData())
            .Returns(new List<Employee>() { new Employee { UniqueId = 1, Salary = 200 } });

        var salaryData = currentDataObject.Object.GetEmployeeData();

        Assert.Contains(salaryData, x => x.Salary > 0);
    }
}