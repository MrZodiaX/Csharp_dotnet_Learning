using Essentials2.Library;
using System.Globalization;

static void Swap<T>(ref T first, ref T second)
//Use swap with ANY TPE without using object, (object causes issues with pass with reference etc.)
{
    T temp = second;
    second = first;
    first = temp;
}

static void Template()
{
    var p1 = new Person
    { FirstName = "shan" };

    var p2 = new Person
    { FirstName = "singh" };

    Console.WriteLine($"before : first {p1.FirstName}, second {p2.FirstName}");
    Swap<Person>(ref p1, ref p2);
    Console.WriteLine($"after : first {p1.FirstName}, second {p2.FirstName}");




    //another template example 
    string jsonPerson = @"{""Id"":0, 
    ""FirstName"":""Matt""}";

    var pj = System.Text.Json.JsonSerializer.Deserialize<Person>(jsonPerson);
    Console.WriteLine($"{pj?.FirstName}");




    Nullable<DateTime> a = null;
    Console.WriteLine(a.GetValueOrDefault());

}

void Template2()
{
    var c = new Customer
    {
        Id = 7,
        FirstName = "lol",
        LastName = "lmao",
        Age = 1,
    };

    var mapper = new customerToPersonMapper();
    //Essentially, we are converting(copying) data from customer to person, 
    //1. using an interface with templated class to do it, hnce it is type independent 
    //2. use a templated method in customer class itself 

    var p = mapper.Map(c);  //1 
    var p2 = c.Map<Person>(mapper); //2
    Console.WriteLine(p.FirstName);
}

//Template();  //generic in terms of c#

//more generic for customerToPerson and Interfacee
Template2();
