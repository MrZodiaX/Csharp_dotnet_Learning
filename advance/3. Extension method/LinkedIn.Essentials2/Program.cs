using Essentials2.Library;
using Essentials2.Library.Extensions;  //has to be in scope for extensions 

//Extension of string 
string s = "ShantanuSingh";
Console.WriteLine($"last 4 characters using extension : {s.Right(4)}");

int num = 4;
Console.WriteLine($"4 sqaured is : {num.Squared()}");


Console.WriteLine("\n_____\n");



var names = new List<string> { "shan", "abc", "defg"};

var shortest  = names.MinBy((s) => s.Length);
Console.WriteLine("Shortest name : "+shortest);

names = names.OrderBy((s) => s.Length).ToList();
foreach (var name in names)
{
	Console.WriteLine(name);
}