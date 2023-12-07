
using System.Text.Json;

public class Utils
{
    // Add your utility methods here

    public static void PrintObject(object obj)
    {
        Console.WriteLine(JsonSerializer.Serialize(obj));
    }
}


