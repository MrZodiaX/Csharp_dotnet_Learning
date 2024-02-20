using Essentials2.Library;
using Essentials2.Library.Extensions;

var employees = new List<Employee>
{
	new Employee{FirstName = "Matt", LastName = "Manager", Id=1},
	new Employee{FirstName = "Felicia", LastName="FinanceDirector", Id=2},
	new Employee{FirstName = "Pinal", LastName="PropertyManagement", Id=3},
	new Employee{FirstName = "Amanda", LastName = "Accounting", Id=4},
	new Employee{FirstName = "Xi", LastName="CXO", Id=5}
};

var filteredEmp = employees.Where((e) => e.Id > 2).Se

foreach (var employee in filteredEmp)
{
	Console.WriteLine(employee.FirstName);
}
