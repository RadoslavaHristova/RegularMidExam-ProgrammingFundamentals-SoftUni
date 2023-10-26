/*
SamsungA50, MotorolaG5, IphoneSE
Add - Iphone10
Remove - IphoneSE
End

HuaweiP20, XiaomiNote
Remove - Samsung
Bonus phone - XiaomiNote:Iphone5
End

SamsungA50, MotorolaG5, HuaweiP10
Last - SamsungA50
Add - MotorolaG5
End

 */

using System.Xml.Linq;

namespace _03.Problem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> phonesList = Console.ReadLine().Split(", ").ToList();

            string command = "";

           
            while ((command = Console.ReadLine()) != "End")
            {
                string[] arguments = command.Split(" - ").ToArray();
                string phoneModel = arguments[1];

                switch (arguments[0])
                {
                    case "Add":

                        if (PhoneExist(phonesList, phoneModel))
                        { break; }

                        else
                        {
                            Add(phonesList, phoneModel);
                        }

                        break;

                    case "Remove":

                        if (PhoneExist(phonesList, phoneModel))
                        {
                            Remove(phonesList, phoneModel);
                        }

                        break;
                    case "Bonus phone":
                        string[] oldNew = arguments[1].Split(":").ToArray();

                        if (PhoneExist(phonesList, oldNew[0]))
                        {
                            int phoneIndex = phonesList.IndexOf(oldNew[0]);

                            if (phoneIndex != -1)
                            {
                                phonesList.Insert(phoneIndex + 1, oldNew[1]);
                            }
                        }
                        break;
                    case "Last":

                        if (PhoneExist(phonesList, phoneModel))
                        {
                            Remove(phonesList, phoneModel);
                            Add(phonesList, phoneModel);
                        }
                        break;
                }
            }
            Console.WriteLine(string.Join(", ", phonesList));
        }

        private static void Remove(List<string> phonesList, string phoneModel)
        {
            phonesList.Remove(phoneModel);
        }

        private static void Add(List<string> phonesList, string phoneModel)
        {
            phonesList.Add(phoneModel);
        }

        private static bool PhoneExist(List<string> phonesList, string phoneModel)
        {
            return phonesList.Contains(phoneModel);
        }
    }
}
