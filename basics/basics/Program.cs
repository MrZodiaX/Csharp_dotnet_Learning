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
    //public Employee()  //default constructior 
    //{ }
    public Employee(string fname, string lname)
    {
        FirstName = fname;
        LastName = lname;
        Id = new System.Random().Next(1,10);
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
    public int NumberOfDirectReports { get; set; }
}

//structs - value types
public struct Age
{
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
    public string LastName { get; set; }
    public int Id { get; set; }
    public Age Age { get; set; }
    public string FirstName { get; set; }
}

public record PremiereCustomer : Customer
{
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
