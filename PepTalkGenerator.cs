using System;
using System.Collections.Generic;

namespace PepTalkGenerator{
    public class PepTalkGenerator{

        private static List<string>[] sectionsOfPep;
        private static Random random = new Random();

        public static readonly PepTalkGenerator Instance = new PepTalkGenerator();
        private PepTalkGenerator(){
            sectionsOfPep = new List<string>[4];
            for(int i = 0; i < 4; i++){
                sectionsOfPep[i] = new List<string>();
            }
            using (var stream = new System.IO.StreamReader("./resources/PepTalkFirst.txt")){
                while(!stream.EndOfStream){
                    sectionsOfPep[0].Add(stream.ReadLine());
                }
            }
            using (var stream = new System.IO.StreamReader("./resources/PepTalkSecond.txt")){
                while(!stream.EndOfStream){
                    sectionsOfPep[1].Add(stream.ReadLine());
                }
            }
            using (var stream = new System.IO.StreamReader("./resources/PepTalkThird.txt")){
                while(!stream.EndOfStream){
                    sectionsOfPep[2].Add(stream.ReadLine());
                }
            }
            using (var stream = new System.IO.StreamReader("./resources/PepTalkFourth.txt")){
                while(!stream.EndOfStream){
                    sectionsOfPep[3].Add(stream.ReadLine());
                }
            }
        }

        private string GetRandomStringFromList(int element){
            return sectionsOfPep[element][random.Next(sectionsOfPep[element].Count)];
        }
        
        public string GeneratePepTalk(){
            var random = new Random();
            return GetRandomStringFromList(0) + " " +
                   GetRandomStringFromList(1) + " " +
                   GetRandomStringFromList(2) + " " +
                   GetRandomStringFromList(3);
        }
    }
}