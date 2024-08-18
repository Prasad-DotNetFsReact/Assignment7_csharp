using System;
using System.IO;

//Using Directory, File, and FileInfo Classes

class Task1
{
    static void Main()
    {
        string mainFolder = "demo";
        string subFolder1 = Path.Combine(mainFolder, "demo1");
        string subFolder2 = Path.Combine(mainFolder, "demo2");

        // Create the main folder and two subfolders
        Directory.CreateDirectory(mainFolder);
        Directory.CreateDirectory(subFolder1);
        Directory.CreateDirectory(subFolder2);

        // Create some files in demo1 folder
        string filePath1 = Path.Combine(subFolder1, "file1.txt");
        string filePath2 = Path.Combine(subFolder1, "file2.txt");

        // Create and write to file using File class
        File.WriteAllText(filePath1, "Hello from file1!");

        // Create and write to file using FileInfo class
        FileInfo fileInfo = new FileInfo(filePath2);
        using (StreamWriter writer = fileInfo.CreateText())
        {
            writer.WriteLine("Hello from file2!");
        }

        // Copy file2.txt to demo2 folder
        string copyFilePath = Path.Combine(subFolder2, "file2_copy.txt");
        File.Copy(filePath2, copyFilePath);

        // Show all files and folders in the main folder
        Console.WriteLine("Contents of 'demo' folder:");
        ShowContents(mainFolder);

        // Show creation time of files and folders
        Console.WriteLine("\nCreation times:");
        ShowCreationTimes(mainFolder);

        // Delete files and folders
        Console.WriteLine("\nCleaning up...");
        DeleteAllFiles(mainFolder);
        DeleteAllFolders(mainFolder);

        Console.WriteLine("All files and folders deleted.");
    }

    static void ShowContents(string path)
    {
        foreach (string dir in Directory.GetDirectories(path))
        {
            Console.WriteLine("Directory: " + dir);
        }
        foreach (string file in Directory.GetFiles(path))
        {
            Console.WriteLine("File: " + file);
        }
    }

    static void ShowCreationTimes(string path)
    {
        foreach (string dir in Directory.GetDirectories(path))
        {
            Console.WriteLine(dir + " was created on: " + Directory.GetCreationTime(dir));
        }
        foreach (string file in Directory.GetFiles(path))
        {
            Console.WriteLine(file + " was created on: " + File.GetCreationTime(file));
        }
    }

    static void DeleteAllFiles(string path)
    {
        foreach (string file in Directory.GetFiles(path))
        {
            File.Delete(file);
        }
    }

    static void DeleteAllFolders(string path)
    {
        foreach (string dir in Directory.GetDirectories(path))
        {
            Directory.Delete(dir, true);
        }
        Directory.Delete(path);
    }
}
