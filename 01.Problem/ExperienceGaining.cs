/*
400
5
50
100
200
100
20

500
5
50
100
200
100
30

500
5
50
100
200
100
20
 */
namespace _01.Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double experienceToUnlock=double.Parse(Console.ReadLine());

            int countOfBattles = int.Parse(Console.ReadLine());
            
            double experience = 0;

            for(int battle=1;battle<=countOfBattles; battle++)
            {
                
                double experiencePerBattle=double.Parse(Console.ReadLine());

                experience += experiencePerBattle;

                if(battle %3 == 0 ) 
                { experience += experiencePerBattle * 0.15; }
                
                
                    if (battle % 5 == 0)
                    { experience -= experiencePerBattle * 0.1; }
                
                if (battle % 15 == 0)
                { experience += experiencePerBattle * 0.05; }

                if(experience>=experienceToUnlock)
                {
                    Console.WriteLine($"Player successfully collected his needed experience for {battle} battles.");
                    break;
                }
            }
            if(experience < experienceToUnlock)
            { Console.WriteLine($"Player was not able to collect the needed experience, {(experienceToUnlock-experience):f2} more needed."); }

        }
    }
}