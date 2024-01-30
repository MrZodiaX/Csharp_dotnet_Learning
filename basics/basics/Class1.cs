using LinkedIn.Essentials;
using System;

Employee employee = new Employee("shan", "singh");
Console.WriteLine($"Hello from {employee.FirstName}");

Employee e = new Manager("shan", "singh");  //obj will get access to Employee variable
Console.WriteLine($"Hello from {e.LastName}");
