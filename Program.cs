using System;
using System.IO;
using System.Collections.Generic;

namespace PepTalkGenerator;
class Program
{
    private static List<string> defaultFileLocations = new(){
        "./resources/PepTalkFirst.txt",
        "./resources/PepTalkSecond.txt",
        "./resources/PepTalkThird.txt",
        "./resources/PepTalkFourth.txt"
    };

    static void Main(string[] args)
    {
        Init();
    }

    private static void Init(){
        if(!File.Exists("./init.skbond")){
            GenerateInit();
        }
        Menu.Run();
    }

    private static void GenerateInit(){
        using(StreamWriter writer = new(File.Create("./init.skbond"))){
            foreach (var s in defaultFileLocations)
            {
                writer.WriteLine(s);
            }
        }
    }
}

