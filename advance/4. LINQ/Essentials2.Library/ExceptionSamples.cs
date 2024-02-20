namespace Essentials2.Library;

using System.Text.Json;

public static class ExceptionSamples
{
    public static void BasicExceptions()
    {
        string wrongPath = "matt.json";
        string rightPath = "..\\..\\..\\matt.json";

        //basic try catch
        string filePath = rightPath;
        //System.IO.Stream fileStream = null;
        Console.WriteLine($"Current Directory-> {Directory.GetCurrentDirectory()}");
        try
        {
            using (var fileStream = File.OpenRead(filePath))
            {

                var matt = JsonSerializer.Deserialize<Employee>(fileStream);

                Console.WriteLine($"Employee read from file: {matt}");
            }
        }
        catch(FileNotFoundException)
        {
            Console.WriteLine("File not found");
        }
        catch (IOException ioex)
        {
            Console.WriteLine($"IO Exception: {ioex.Message}");
        }
        catch(JsonException jsoex) when (jsoex.Message.Contains("converted", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"JSON exception: {jsoex.Message}");
        }
        //FOLLOW UP: add a catch block with a when statement to catch problems with syntax (missing comma e.g.)
        catch(JsonException jsoex) //optional to add when for specific case// when (jsoex.Message.Contains("invalid", StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"General JSON exception: {jsoex.Message}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Standard exception caught: {ex.Message}");
        }
        
        finally
        {
            //if (fileStream != null)
            //{
            //    fileStream.Dispose();
            //}
        }
    }

    public static void ThrowExceptions(bool? shouldThrow)
    {
        if (!shouldThrow.HasValue)
        {
            throw new ArgumentNullException("shouldThrow");
        }

        if (shouldThrow.Value)
        {
            //BEST PRACTICE = do NOT throw System.Exception like this
            //throw new Exception("I was told to throw this!");
            throw new InvalidOptionException("I was told to throw this!");
        }
        else
        {
            Console.WriteLine("No exceptions being thrown here.");
        }
    }
}
