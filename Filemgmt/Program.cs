using System;
using System.IO;

namespace StudentFilesApp
{
    class Program
    {
        static void Main(string[] args)
        {
          
            string directoryPath = @"C:\Users\Public\StudentFiles";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            
            string[] studentNames = new string[3];
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"Enter name of student {i + 1}: ");
                studentNames[i] = Console.ReadLine();
            }

            
            foreach (string studentName in studentNames)
            {
                string filePath = Path.Combine(directoryPath, $"{studentName}.txt");
                Console.Write($"Enter a note for {studentName}: ");
                string note = Console.ReadLine();
                File.WriteAllText(filePath, note);
            }

           
            Console.WriteLine("\nFiles created:");
            string[] files = Directory.GetFiles(directoryPath);
            foreach (string file in files)
            {
                Console.WriteLine(file);
            }

           
            Console.WriteLine("\nReading files...");
            foreach (string file in files)
            {
                string content = File.ReadAllText(file);
                Console.WriteLine($"{Path.GetFileName(file)}: {content}");
            }
        }
    }
}
