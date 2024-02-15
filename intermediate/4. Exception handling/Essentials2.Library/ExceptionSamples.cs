namespace Essentials2.Library;

using System.Text.Json;

public class ExceptionSamples
{
	public static string wrongPath = "matt.json";
	public static string rightPath = "..\\..\\..\\matt.json";

	public static void BasicExceptions()
    {
        //basic try catch
        string filePath = wrongPath;

        //FILE HANDLING 
        System.IO.Stream fileStream = null;
        Console.WriteLine($"Current Directory-> {Directory.GetCurrentDirectory()}");
        try
        {
            fileStream = File.OpenRead(filePath);
            var matt = JsonSerializer.Deserialize<Employee>(fileStream);
            Console.WriteLine($"Employee read from file: {matt}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Standard exception caught: {ex.Message}");            
		}
        finally  //execute no matter 
        {
            if (fileStream != null)
            {
                fileStream.Dispose(); 
            }
        }
    }

    public static void BasicExceptions_catching()
    {
        //need to dispose using filestream 
        //by using below, no need to dispose as it will dispose after using block 

        try
        {
            using (var fileStream = File.OpenRead(rightPath))
            {
				var matt = JsonSerializer.Deserialize<Employee>(fileStream);
				Console.WriteLine($"Employee read from file: {matt}");
			}
        }
		//specialised exception can preceed normal excp
		catch (FileNotFoundException ff) when (ff.Message.Contains("file", StringComparison.OrdinalIgnoreCase))
        {
			Console.WriteLine("FileNotFound occured : " + ff);
		}
		catch (IOException ioex)  
        {
            Console.WriteLine("IOEx occured : "+ioex);
		}
		catch (JsonException jsex) when (jsex.Message.Contains(",", StringComparison.OrdinalIgnoreCase))
		{
			Console.WriteLine("Json occured : " + jsex);
		}
		catch (Exception ex)
        {
            Console.WriteLine("Exception occured : "+ex);
        }
    }

    public static void ThrowExceptions(bool? shouldThrow)
    {
        if(!shouldThrow.HasValue)
        {
            throw new ArgumentNullException("ShouldThrow Null");
        }
		else
        {
			//throw new Exception("Throw exception");
			throw new invalidOptionException("Throwing exception using class");
		}
    }
}