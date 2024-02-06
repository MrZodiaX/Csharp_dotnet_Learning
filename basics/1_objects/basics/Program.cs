namespace LinkedIn.Essentials;

public interface IPerson
{

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Id { get; set; }
    public Age Age { get; set; }
}

//classes - reference types
public class Employee : IPerson
{
    //ctor and tab
    public Employee()  //default constructior 
    {
        Id = 5;
    }


    public Employee(string fname)  //default constructior 
    { }


    public Employee(string fname, string lname, int Id = 0)
    {
        FirstName = fname;
        LastName = lname;
        if(Id!=0) Id = new System.Random().Next(1,10);
    }
    public string LastName { get; set; }
    public int Id { get; set; }
    public Age Age { get; set; }
    public string FirstName { get; set; }

    //employee properties
    public int EmployeeId { get; set; }
    public DateOnly StartDate { get; set; }
    public TimeOnly ShiftStartTime { get; set; }
}

public class Manager : Employee, IPerson
{
    //public Manager() : base("Unknown", "lol")  //if constructor takes argument, use base metho 
    //or 
    public Manager(string f, string l) : base(f,l)  
    { }

    public void SetReport(int NOOfRepo)
    {
        NumberOfDirectReports = NOOfRepo;
    }
    public int NumberOfDirectReports { get; private set; }
}

//structs - value types
public struct Age
{
    public Age(DateTime dob, int ag)  //shortcut ctor tab, have to assign value to Birthdate and years bcos struct 
    {
        BirthDate = dob;
        YearsOld = ag;
    }
    public DateTime BirthDate { get; set; }
    public int YearsOld { get; set; }
}

public struct VendorContact : IPerson
{
    public string LastName { get; set; }
    public int Id { get; set; }
    public Age Age { get; set; }
    public string FirstName { get; set; }
}

//records (C# 9)
public record Customer : IPerson
{
    public Customer()
    {
        
    }
    public Customer(string ln, int id) //not required init here 
    {
        LastName = ln;
        Id = id;

    }
    public string LastName { get; set; }
    public int Id { get; set; }
    public Age Age { get; set; }
    public string FirstName { get; set; }
}

public record PremiereCustomer : Customer
{
    public PremiereCustomer(byte clev)
    {
        CustomerLevel = clev;
    }
    public byte CustomerLevel { get; init; }
}

//record structs (C# 10)
public record struct Order
{
    public int OrderId { get; set; }
    public DateOnly OrderDate { get; set; }

}
public record struct RecurringOrder
{

}
