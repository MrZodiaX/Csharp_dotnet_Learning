using Essentials2.Library;


/*
 


//delegate is a pointer to a method or function 
Delegate del = WriteHello;
del.DynamicInvoke("Shan");

DelegateSamples.PassMeWork(WriteHello);
*/

static void WriteHello(string nam)
{
	Console.WriteLine($"hello {nam}");
	//DelegateSamples.SomethingHappened -= WriteHello;  //cleaning
}

/*
static void cbFun(string info)
{
	Console.WriteLine("Got data in cb : " + info);
}

//subscriber 
DelegateSamples.SomethingHappened += WriteHello;
DelegateSamples.SomethingHappened += cbFun;

//invoking

DelegateSamples.DoSomething();
Console.WriteLine("");
DelegateSamples.DoSomething();


*/


//cancel key press event 
/*
Console.CancelKeyPress += OnCancel;
for(int i=0;i<20;i++)
{
	Console.WriteLine("Writing " + i);
	Thread.Sleep(100);
}
Console.CancelKeyPress -= OnCancel;
Console.WriteLine($"Done");
static void OnCancel(object sender, ConsoleCancelEventArgs args)  //default syntax of event handlers 
{
	Console.WriteLine($"Cancelled...");
	args.Cancel = true; //allow this to cancel or not 
*/

DelegateSamples.PassMeWork2(WriteHello);

DelegateSamples.PassMeLogic(calculateLen);

static int calculateLen(string ip)
{
	return ip.Length;
}

Console.WriteLine("\n-----\n");

//lambda 
var t = (string s) => Console.WriteLine(s);
var t2 = (string s) => s.Length; //returns len 

t("Hello lambda");
Console.WriteLine($"len of shan : {t2("Shan")}");

var c = (string s) =>
{
	Console.WriteLine(s);
	return s.Length;
};


//passing expression instead of method 
DelegateSamples.PassMeWork((s)=>Console.WriteLine("Hello expression:"+s));


Console.WriteLine("\n-----\n");

//Exercise 
static int FindLargestNum(int[] arr)
{
    int i = Int32.MinValue;
    foreach (int x in arr)
    {
        if (x > i) i = x;
    }
    return i;
}
int[] numbers = { 7, 17, 13, 19, 5 };
int learnerResult = DelegateSamples.FindLargest(numbers, FindLargestNum);
Console.WriteLine("Largest number is : " + learnerResult);

