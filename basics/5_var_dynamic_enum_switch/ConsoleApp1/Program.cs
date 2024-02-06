using ConsoleApp1;
using System.Diagnostics.CodeAnalysis;

a lol = new b();   //parent class variable 
((b)lol).b1 = 22;  //typecase of parent to childclass

void varVariable()
{

    var x = 10;   //type is decided at runtime 
    var y = "sjasd";

    var e = new b();
    e.a1 = 20;
    e.b1 = 23;
    Console.WriteLine(e.a1);
    Console.WriteLine(e.b1);


    var newVar = new
    {
        a1 = 222,
        b1 = 333,
        kids = new string[] { "son1", "son2" }
    };
    Console.WriteLine(newVar.kids[1]);
    Console.WriteLine(newVar.GetType());
    Console.WriteLine(e.GetType());

}

void dynamicVariables()
{
    dynamic d = new b() { b1 = 233 };
    //string kids = d.Kids[1];  //no kids in b() yet no compile time error due to dynamic

    //dynamic : we know type at runtime, but not at compile time

    Console.WriteLine(d.GetType());
    Console.WriteLine(d.b1);
}


void enumType()
{
    var Allday = DayOfWeek.Thursday;

    var ok = days.wednesday;
    Console.WriteLine((int)ok);

    days day = days.munday | days.sunday;  //bitwise or  10 | 01 => 11(3, tuesday)
    Console.WriteLine(day);

    days okk = days.munday;

    Console.WriteLine($"valid : {okk.HasFlag(days.tuesday)}");
    bool ll = (okk & days.munday) == days.tuesday;
    Console.WriteLine($"valid : {ll}");

    //others - view all values of enum
    var temp = System.Enum.GetNames(typeof(days));
    Console.WriteLine(String.Join(", ", temp));

    var temp2 = (int[])System.Enum.GetValues(typeof(days));
    Console.WriteLine(String.Join(",", temp2));
}


string getFormat([AllowNull]string s)
{
    if (s == null) 
        return "Null val";
    else
        return s.Trim().PadLeft(5, '*');
}
void nullableTypes()
{
    string ip = null;
    int lolNoNull; //int cannot have null 
    int? lol = null;  //? can make int have null 
    Nullable<int> lol2 = null;

    if (lol == null) Console.WriteLine("lol is null");
    if (lol.HasValue) Console.WriteLine("lol is NOT null");

    //lolNoNull = lol2;  //cant do, lol2 could be null
    lolNoNull = lol2 ?? 12;  //if lol2 is null, assign 12
    lol2 ??= 69;   //if lol2 is null, assign 69 to it 
    Console.WriteLine(lolNoNull);


    //  ? to tackle null 
    string s = "  abc "; // null;
    //s = null;

    //string ans = s?.Trim()?.PadLeft(5, '*');  //if s do trim, it trimmed, do padding 

    string ans = getFormat(s); 

    // trims leading and trailing whitespaces 
    ans = ans ?? "String is null";
    Console.WriteLine(ans);
}

static string getDay(days day) => day switch
{
    days.munday => "monday lol",
    days.sunday => "sunday lol",
    days.tuesday => "tuesday lol",
    _ => "NOT a validday"   //default type
};

void switchStateAlternate()
{
    var shiftDay = getDay((days)3);
    Console.WriteLine(shiftDay);

    days dd = days.wednesday;
    //Iline switch 
    int temp = 0;
    var result = dd switch
    {
        days.munday => "monday lol",
        days.sunday => "sunday lol",
        _ => "default lol"
    };


    //Other way to switch 
    var testDate = new DateTime(2022, 1, 2, 16, 0, 0);
    var isWeekend = testDate switch
    {
        { Hour: >= 15, DayOfWeek: DayOfWeek.Saturday or DayOfWeek.Sunday } => true,
        _ => false
    };
    Console.WriteLine(isWeekend ? "weekend": "weekday");





    a obj1 = new a();
    b? objB = obj1 as b;  //new way for type conversion, similar to (b)obj1
    bool lol = (obj1 is b);   //NEW way to check 
    if(lol)
    {
        Console.WriteLine("Type conversion");
    }
    else
    {
        Console.WriteLine("failed conversion");
    }
}

//varVariable();
//dynamicVariables(); 
//enumType();


//nullableTypes();

switchStateAlternate();