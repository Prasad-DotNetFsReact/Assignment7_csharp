using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.IO;

class Task2

{
    static void Main()
    {
        string fileName = string.Empty;

        while (true)
        {
            Console.WriteLine("\nMenu:");
            Console.WriteLine("1. Create a new file");
            Console.WriteLine("2. Write text to the file");
            Console.WriteLine("3. Add more text to the file");
            Console.WriteLine("4. Show text line by line");
            Console.WriteLine("5. Show all text at once");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option (1-6): ");

            int choice = Convert.ToInt32(Console.ReadLine());

            try
            {
                switch (choice)
                {
                    case 1:
                        Console.Write("Enter file name: ");
                        fileName = Console.ReadLine();
                        using (FileStream fs = new FileStream(fileName, FileMode.Create))
                        {
                            Console.WriteLine($"File '{fileName}' created.");
                        }
                        break;

                    case 2:
                        Console.Write("Enter text to write: ");
                        string text = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(fileName))
                        {
                            sw.WriteLine(text);
                        }
                        Console.WriteLine("Text written to the file.");
                        break;

                    case 3:
                        Console.Write("Enter text to append: ");
                        string appendText = Console.ReadLine();
                        using (StreamWriter sw = new StreamWriter(fileName, true))
                        {
                            sw.WriteLine(appendText);
                        }
                        Console.WriteLine("Text appended to the file.");
                        break;

                    case 4:
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            string line;
                            while ((line = sr.ReadLine()) != null)
                            {
                                Console.WriteLine(line);
                            }
                        }
                        break;

                    case 5:
                        using (StreamReader sr = new StreamReader(fileName))
                        {
                            string content = sr.ReadToEnd();
                            Console.WriteLine("File content:");
                            Console.WriteLine(content);
                        }
                        break;

                    case 6:
                        return;

                    default:
                        Console.WriteLine("Please choose a valid option.");
                        break;
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }
    }
}

