namespace LinkedIn.Essentials;

public interface IPerson
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
public abstract class Employee : IPerson
{
    //IPerson
    public string LastName { get; set; }
    public string FirstName { get; set; }


    public DateOnly StartDate { get; set; }

    //virtual property
    public virtual DateTime EndDate { get; set; }

    //abstract property
    public abstract int EmployeeId { get; }

    //derived must implement
    public abstract bool ProcessPayroll();  

    //derived can implement
    public virtual void Terminate(DateTime terminationEffectiveDate)
    {
        Console.WriteLine("base : Employee terminated");
        EndDate = terminationEffectiveDate;
    }

    //derived can call or hide
    public bool IsActive()
    {
        Console.WriteLine("base : Employee Active");
        DateOnly current = DateOnly.FromDateTime(DateTime.Now);
        return current > StartDate && DateTime.Now < EndDate;
    }
}

public class ShiftWorker : Employee
{
    public TimeOnly ShiftStartTime { get; set; }
    public override int EmployeeId { get => 1; }

    public override bool ProcessPayroll()  //HAVE to provide implementation of methods and properties marked as abstract in base class, using override modifier
    {
        Console.WriteLine("overriden : Shiftworker payroll");
        return true;
    }
    public new bool IsActive()  //new modifier used, bcos we have this method in base class
    {
        //base.IsActive();  //can be used like this from base class
        Console.WriteLine("New : Shiftworker active");
        return false;
    }
}
public class Manager : Employee, IPerson
{
    public int NumberOfDirectReports { get; set; }
    public override int EmployeeId { get=> new System.Random().Next(1,100); }

    public override bool ProcessPayroll()
    {
        Console.WriteLine("Manager payroll");
        return true;
    }

    public override void Terminate(DateTime terminationEffectiveDate)
    {
        //perform manager specific termination steps
        Console.WriteLine("Manager terminated");

        //optional - call base implementation
        base.Terminate(terminationEffectiveDate);
    }
}
