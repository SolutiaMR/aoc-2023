using System;
using System.IO;

public class FileProcessor
{
    private string filePath;

    public FileProcessor(string filePath)
    {
        this.filePath = filePath;
    }

    public string[] ReadFile()
    {
        try
        {
            return File.ReadAllLines(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
            return null;
        }
    }


    public string[] ParseFileByDelimiter(string delimiter)
    {
        try
        {
            string[] lines = ReadFile();
            if (lines != null)
            {
                string[] parsedData = new string[lines.Length];
                for (int i = 0; i < lines.Length; i++)
                {
                    parsedData[i] = lines[i].Split(delimiter)[0]; // Assuming we want the first part of each line
                }
                return parsedData;
            }
            else
            {
                return null;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error parsing file: {ex.Message}");
            return null;
        }
    }
}
