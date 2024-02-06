using LinkedIn.Essentials;

Employee sw = new ShiftWorker  
{
    FirstName = "staff",
    LastName = "one",
    StartDate = new DateOnly(2014, 2, 17),
    ShiftStartTime = new TimeOnly(8, 30)
};


//Console.WriteLine("=============Shift Worker=============");
//bool payrollProcessed = sw.ProcessPayroll();  //overriden func run 
//sw.Terminate(DateTime.Now);  //base terminate 
//bool active = sw.IsActive(); //base active because Employee ka variable hai, Shiftworker ka variable hota to new wala chalta
//but if, isActive overriden hota, to overriden ka call hota regardless kaunsa variable hai 
//Console.WriteLine();


Employee mgr = new Manager
{
    FirstName = "manager",
    LastName = "one",
    NumberOfDirectReports = 7
};

Console.WriteLine("=============Manager=============");
bool mgrPayrollProcessed = mgr.ProcessPayroll(); 
mgr.Terminate(DateTime.Now);  //terminate of manager will be called even if employees variable, because terminate overriden in manager
bool mgrActive = mgr.IsActive();





////////////////////////////////////////////////////////////////////////////////////
//using static class


string lo = Class1.key;  //no instance/obj needed 
string pass = Class1.password;
int lol = Class1.getKey();