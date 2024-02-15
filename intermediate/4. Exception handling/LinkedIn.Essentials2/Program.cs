using Essentials2.Library;



//ExceptionSamples.BasicExceptions_catching();

try { ExceptionSamples.ThrowExceptions(true);  }
catch (Exception e)  { Console.WriteLine(e);  }

Console.WriteLine("");

  
//unhandeled exception
try{ ExceptionSamples.ThrowExceptions(true);  }
catch (Exception ex) 
{
	//throw; 
	throw new ApplicationException("App exception", ex);
}



