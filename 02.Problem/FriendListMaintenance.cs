/*
Mike, John, Eddie
Blacklist Mike
Error 0
Report

Mike, John, Eddie, William
Error 3
Error 3
Change 0 Mike123
Report
 */
namespace _02.Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string>friendsList=Console.ReadLine().Split(", ").ToList();

            string command = "";

            List<string> blacklisted = new List<string>();
            List<string> lostNames = new List<string>();

            while ((command = Console.ReadLine()) != "Report")
            {
                string[] arguments = command.Split().ToArray();
                

                switch(arguments[0])
                {
                    case "Blacklist":
                        string name = arguments[1];

                        if(friendsList.Contains(name))
                        {
                            int nameIndex = friendsList.IndexOf(name);

                            if(nameIndex != -1)
                            {
                                friendsList[nameIndex] = "Blacklisted";
                            }
                            Console.WriteLine($"{name} was blacklisted.");
                            blacklisted.Add(name);
                        }
                        else
                        { Console.WriteLine($"{name} was not found."); }

                        break;
                    case "Error":
                        int index = int.Parse(arguments[1]);

                        if (IndexIsValid(friendsList,index))
                        { if (friendsList[index]=="Blacklisted"
                                || friendsList[index]=="Lost")
                            { continue; }
                        else
                            { Console.WriteLine($"{friendsList[index]} was lost due to an error.");
                                lostNames.Add(friendsList[index]);
                                friendsList[index] = "Lost";
                            }
                                    }
                        break;
                    case "Change":
                        string newName = arguments[2];
                        index = int.Parse(arguments[1]);

                        if (IndexIsValid(friendsList, index))
                        {
                            if (friendsList[index] != "Lost"&& friendsList[index]!= "Blacklisted") 
                            {
                                Console.WriteLine($"{friendsList[index]} changed his username to {newName}.");
                                friendsList[index] = newName;
                            }
                        }
                        break;
                }
            }
            
            Console.WriteLine($"Blacklisted names: {blacklisted.Count}");
            Console.WriteLine($"Lost names: {lostNames.Count}");
            Console.WriteLine(string.Join(" ",friendsList));
        }

        private static bool IndexIsValid(List<string> friendsList, int index)
        {
            return index>=0&&index<friendsList.Count;
        }
    }
}