using Essentials2.Library;
//delegate is a pointer to a method or function 
Delegate del = WriteHello;
del.DynamicInvoke("Shan");

DelegateSamples.PassMeWork(WriteHello);
static void WriteHello(string nam)
{
	Console.WriteLine($"hello {nam}");
	DelegateSamples.SomethingHappened -= WriteHello;  //cleaning
}

DelegateSamples.SomethingHappened += WriteHello;

DelegateSamples.DoSomething();

Console.CancelKeyPress += OnCancel;
for(int i=0;i<40;i++)
{
	Console.WriteLine("Writing" + i);
	Thread.Sleep(100);
}
Console.CancelKeyPress -= OnCancel;
Console.WriteLine($"Done");
static void OnCancel(object sender, ConsoleCancelEventArgs args)  //default syntax of event handlers 
{
	Console.WriteLine($"Cancelled...");
	args.Cancel = false; //allow this to cancel or not 
}