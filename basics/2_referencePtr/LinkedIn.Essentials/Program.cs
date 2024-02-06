// See https://aka.ms/new-console-template for more information
using LinkedIn.Essentials;

//Classes();
Structs();
//Records();


static void Classes()
{
    Console.WriteLine("=========== Classes = reference types ===========");
    //Create an employee
    Employee me = new Employee
    {
        FirstName = "initFname",
    };

    //create another reference to the employee
    IPerson other = me;
    other.FirstName = "ChangedFname";

    //examine results of the original object, CHANGED
    Console.WriteLine($"me: {me.FirstName}, parChanged : {other.FirstName} ");
    Console.WriteLine();

    ChangeName(other);
    //ChangeName(ref other);  //sent as reference 

    Console.WriteLine($"After method isover : {other.FirstName}  ");

    Console.WriteLine();
}

static void ChangeName( IPerson person)
{
    person.FirstName = "ChangedFnameInMethod";
    Console.WriteLine($"Person in method is {person.FirstName}");

    person = new Manager("ChangedFnameInMethodAgain", "manager");
    //now person is local, and changes will not reflect outside function

    Console.WriteLine($"Person after reference change in method is {person.FirstName}");
}



////////////////////////////////////////////////////////////////////



static void Structs()
{
    Console.WriteLine("=========== Structs = value types ===========");

    Age myAge = new Age { BirthDate = new DateTime(1971, 9, 1), YearsOld = 50 };
    Age anotherAge = myAge;

    anotherAge.YearsOld = 100;   //anotherAge is value type, will not change myAge

    Console.WriteLine($"My age is {myAge.YearsOld}, but I changed it to {anotherAge.YearsOld}"); //DIFFERENT FROM CLASS

    AgeBackwords(ref anotherAge); //without ref, age will not change

    Console.WriteLine($"Now I am {anotherAge.YearsOld}");
    Console.WriteLine();
}
static void AgeBackwords(ref Age startingAge)
{
    startingAge.YearsOld = 500;
    Console.WriteLine($"Modified age in method: {startingAge.YearsOld}");
}



////////////////////////////////////////////////////////////////////



static void Records()
{
    Console.WriteLine("=========== Records = reference or value types ===========");

    PremiereCustomer pc = new PremiereCustomer
    {
        FirstName = "RecordInit",
    };

    PremiereCustomer pc2 = pc with { FirstName = "RecordChanged"};

    Console.WriteLine($"pc : {pc.FirstName}");
    Console.WriteLine($"pc2 : {pc2.FirstName}");
    ChangeName((IPerson)pc);
    Console.WriteLine($"after method : {pc.FirstName} ");
}




/*
 Two things 

if we create a copy of object, it is a copy in struct and record, but in class it is a reference 

if we send the object to a function, by default it is sent using copy so it cannot make change, 
but if used ref keyword, it will make change 
 */






