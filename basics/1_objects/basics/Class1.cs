using LinkedIn.Essentials;
using System;


void basicsOfObjects()
{
    Employee employee = new Employee("shan", "singh");
    Console.WriteLine($"Hello from {employee.FirstName}");

    Employee e = new Manager("shan", "singh");  //obj will get access to Employee variable
    Console.WriteLine($"Hello from {e.LastName}");



    Employee e1 = new Employee
    {  //will use default constructor in this case
        FirstName = "Shan",
        LastName = "sinn",
    };

    Console.WriteLine($"Id from default const : {e1.Id}");

    PremiereCustomer pp = new PremiereCustomer(1);
    pp.FirstName = "lol";
    //pp.CustomerLevel = 1;  //init only property 

    Manager M = new Manager("b", "oss");
    //M.NumberOfDirectReports = 1;  //private set hence inaccessable 
    M.SetReport(1);  //use method instead 
}


void testout()
{
    Employee em = new Employee("shan", "__", 20);

    IPerson per = em;
    per.FirstName = "zodiac";
    per.Id = 100;

    Console.WriteLine($"EM : Name : {em.FirstName}, age : {em.Id}");
    Console.WriteLine($"per : Name : {per.FirstName}, age : {per.Id}");

    //ChangeName();


}


basicsOfObjects();
testout();

