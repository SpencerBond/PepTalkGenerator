using System;

namespace PepTalkGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            do{
                System.Console.Clear();
                System.Console.WriteLine(PepTalkGenerator.Instance.GeneratePepTalk());
                System.Console.WriteLine("Press Y For A New Pep Talk. Press Any Other Key To Exit.");
            }while(System.Console.ReadLine().ToUpper().Equals("Y"));
        }
    }
}
