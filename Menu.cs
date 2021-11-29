using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;

namespace PepTalkGenerator;

public class Menu{
    private static int userInput;

    public static void Run(){
        MainMenu();
    }

    private static void MainMenu(){
        Console.Clear();
        Console.WriteLine("Welcome to Spencer's Pep Talk Generator!");
        Console.WriteLine("Default Pep Talks are taken from this Reddit post: skbond.me/peporigin");
        Console.WriteLine();
        do{
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Generate Pep Talk");
            Console.WriteLine("2: Add/Remove Pep Talk Options");
            Console.WriteLine("3: Change Path");
            Console.WriteLine("0: Exit");
        }while(!GetUserInput(3, out userInput));
        switch (userInput){
            case 1:
                PepTalkMenu();
                break;
            case 2:
                ModifyPepMenu();
                break;
            case 3:
                ChangePathMenu();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Thank you for using Pep Talk Generator!");
                Environment.Exit(0);
            break;
        }
        
    }

    private static void PepTalkMenu(){
            Console.Clear();
            Console.WriteLine(PepTalkGenerator.Instance.GeneratePepTalk());
        do{
            Console.WriteLine();
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1: Generate New Pep Talk");
            Console.WriteLine("2: Return to Main Menu");
            Console.WriteLine("0: Exit");
        }while(!GetUserInput(2, out userInput));
        switch (userInput){
            case 1:
                PepTalkMenu();
                break;
            case 2:
                MainMenu();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Thank you for using Pep Talk Generator!");
                Environment.Exit(0);
                break;
        }
    }

    private static void ModifyPepMenu(){
        Console.Clear();
        Console.WriteLine("Please select the file you wish to modify:");
        do{
            Console.WriteLine();
            for(int i = 0; i < PepTalkGenerator.Instance.pepLocations.Count; i++){
                Console.WriteLine($"{i + 1}: {PepTalkGenerator.Instance.pepLocations[i]}");
            }
            Console.WriteLine($"{PepTalkGenerator.Instance.pepLocations.Count + 1}: Back to Main Menu");
            Console.WriteLine("0: Exit");
        }while(!GetUserInput(PepTalkGenerator.Instance.pepLocations.Count + 1, out userInput));
        switch (userInput){
            case 1:
            case 2:
            case 3:
            case 4:
                LaunchTextEditor(userInput);
                System.Console.WriteLine("Closing program. Changes will take effect on relaunch.");
                Console.WriteLine("Thank you for using Pep Talk Generator!");
                break;
            case 5:
                MainMenu();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Thank you for using Pep Talk Generator!");
                Environment.Exit(0);
                break;
        }
    }

    private static void ChangePathMenu(){
        Console.Clear();
        Console.WriteLine("Please select which location you want to change:");
        do{
            Console.WriteLine();
            for(int i = 0; i < PepTalkGenerator.Instance.pepLocations.Count; i++){
                Console.WriteLine($"{i + 1}: {PepTalkGenerator.Instance.pepLocations[i]}");
            }
            Console.WriteLine($"{PepTalkGenerator.Instance.pepLocations.Count + 1}: Back to Main Menu");
            Console.WriteLine("0: Exit");
        }while(!GetUserInput(PepTalkGenerator.Instance.pepLocations.Count + 1, out userInput));
        switch (userInput){
            case 1:
            case 2:
            case 3:
            case 4:
                ModifyPath(userInput);
                System.Console.WriteLine("Closing program. Changes will take effect on relaunch.");
                Console.WriteLine("Thank you for using Pep Talk Generator!");
                break;
            case 5:
                MainMenu();
                break;
            default:
                Console.Clear();
                Console.WriteLine("Thank you for using Pep Talk Generator!");
                Environment.Exit(0);
                break;
        }
    }

    private static bool GetUserInput(int i, out int selection){
        bool isValidInput = true;
        System.Console.Write("Input Selection: ");
        if(!int.TryParse(Console.ReadLine(), out selection) || selection > i || selection < 0){
            System.Console.WriteLine("Invalid Selection. Please try again.");
            isValidInput = false;
        }
        return isValidInput;
    }

    private static void LaunchTextEditor(int file){
        Process.Start("notepad.exe", PepTalkGenerator.Instance.pepLocations[file - 1]);
    }

    private static void ModifyPath(int file){
        string filePath;
        System.Console.Clear();
        System.Console.WriteLine($"Reassigning path: {PepTalkGenerator.Instance.pepLocations[file - 1]}");
        do{
            System.Console.WriteLine();
            System.Console.Write("Input new file's absolute or relative path: ");
            filePath = Console.ReadLine();
        }while(!File.Exists(filePath));
        PepTalkGenerator.Instance.pepLocations[file - 1] = filePath;
        File.Delete("./init.skbond");
        using(StreamWriter writer = new(File.Create("./init.skbond"))){
            foreach (var s in PepTalkGenerator.Instance.pepLocations)
            {
                writer.WriteLine(s);
            }
        }
    }
}