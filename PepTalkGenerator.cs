using System;
using System.IO;
using System.Collections.Generic;

namespace PepTalkGenerator;
public class PepTalkGenerator{

    public List<string> pepLocations;
    private static List<string>[] sectionsOfPep;
    private static Random random;

    public static readonly PepTalkGenerator Instance = new PepTalkGenerator();
    private PepTalkGenerator(){
        pepLocations = new();
        sectionsOfPep = new List<string>[4];
        random = new();

        using(StreamReader reader = new(File.Open("./init.skbond", FileMode.Open))){
            while(!reader.EndOfStream){
                pepLocations.Add(reader.ReadLine());
            }
        }

        for(int i = 0; i < 4; i++){
            sectionsOfPep[i] = new();
        }

        using (StreamReader reader = new(pepLocations[0])){
            while(!reader.EndOfStream){
                sectionsOfPep[0].Add(reader.ReadLine());
            }
        }
        using (StreamReader reader = new(pepLocations[1])){
            while(!reader.EndOfStream){
                sectionsOfPep[1].Add(reader.ReadLine());
            }
        }
        using (StreamReader reader = new(pepLocations[2])){
            while(!reader.EndOfStream){
                sectionsOfPep[2].Add(reader.ReadLine());
            }
        }
        using (StreamReader reader = new(pepLocations[3])){
            while(!reader.EndOfStream){
                sectionsOfPep[3].Add(reader.ReadLine());
            }
        }
    }

    private string GetRandomStringFromList(int element){
        return sectionsOfPep[element][random.Next(sectionsOfPep[element].Count)];
    }
    
    public string GeneratePepTalk(){
        return GetRandomStringFromList(0) + " " +
                GetRandomStringFromList(1) + " " +
                GetRandomStringFromList(2) + " " +
                GetRandomStringFromList(3);
    }
}
