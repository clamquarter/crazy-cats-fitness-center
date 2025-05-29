using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace FitnessCenter
{
    internal class FitnessCenter
    {
        public static void Launch()
        {
            //list of Clubs (at least four)
            List<Club> clubs = new List<Club>();

            Club planetFitness = new Club("Planet Fitness", "123 Fit St.");
            Club laFitness = new Club("LA Fitness", "456 Fit St.");
            Club hourFitness = new Club("24 Hour Fitness", "1000 Main St.");
            Club kianasBasement = new Club("Kiana's Basement", "123 Mulberry St.");

            clubs.Add(planetFitness);
            clubs.Add(laFitness);
            clubs.Add(hourFitness);
            clubs.Add(kianasBasement);
            //list of Members?

            //how will we check status at check in?
            MultiClub india = new MultiClub("Kiana");
            SingleClub india2 = new SingleClub("India", kianasBasement);
            SingleClub youssef = new SingleClub("Youssef", laFitness);
            //display associated fees (lower fees for different member classes)

            string nameInput;
            string clubType = "";
            string possibleClub = "";
            string userSelection;
            Console.WriteLine("\n Welcome to the Fitness Center\n");
            Console.Write("What is your Name? ");
            nameInput = Console.ReadLine();

            string[] possibleClubs = { "multi club", "multi", "single club", "single" };

            clubType = HandleClubType(possibleClubs);

            if (((string[])["single", "single club"]).Contains(clubType))
            {
                HandleSingleClub(nameInput, possibleClub, clubs);
            }
            else if (new string[] { "multi", "multi club" }.Contains(clubType))
            {
                HandleMultiClub(nameInput,clubs);
            }

            userSelection = CheckOrBill();

            if (userSelection == "check in")
            {
                CheckIn(possibleClub, nameInput, clubs);
            } else if (userSelection == "view bill" || userSelection == "bill")
            {
                Console.Write(planetFitness.DisplayMember(FindMember(nameInput, clubs)));
            } else if (userSelection == "exit")
            {
                Console.WriteLine("DO STUFF");
            }
        }
        private static Member FindMember(string name, List<Club> clubs)
        {
            Member foundMember = null;
            bool found = false;
            foreach (Club club in clubs)
            {
                foreach (Member member in club.Members)
                {
                    if (member.Name == name)
                    {
                        foundMember = member;
                        found = true;
                    }
                }
            }

            if (!found)
            {
                Console.WriteLine("Frank was displeased.");
            }
            return foundMember;
        }
        private static void HandleSingleClub(string nameInput, string possibleClub, List<Club> clubs)
        {
            bool validInput = false;
            do
            {
                DisplayClubs(clubs);
                Console.Write("Please choose the club type you want to join: ");
                possibleClub = Console.ReadLine().Trim().ToLower();
                validInput = clubs.Select(club => club.Name.ToLower()).Contains(possibleClub);
                if (!validInput)
                {
                    possibleClub = IsPossibleClub(possibleClub, clubs);
                    if (possibleClub != "")
                    {
                        validInput = true;
                    }
                }
            } while (!validInput);

            foreach (Club club in clubs)
            {
                if (club.Name.ToLower() == possibleClub)
                {
                    club.Members.Add(new SingleClub(nameInput, club));
                }
            }
        }
        private static void HandleMultiClub(string nameInput, List<Club> clubs)
        {
            foreach (Club club in clubs)
            {

                club.Members.Add(new MultiClub(nameInput));
            }
        }
        private static string CheckOrBill()
        {
            string userSelection = "";
            bool validInput = false;
            do
            {
                DisplayCheckInOrBillMenu();
                userSelection = Console.ReadLine().Trim().ToLower();
                validInput = new string[] { "check in", "view bill", "bill", "exit" }.Contains(userSelection);
                if (!validInput)
                {
                    userSelection = IsPossibleCheckInOrBillOrExit(userSelection);
                    if (!((string[])["check in", "view bill", "exit"]).Contains(userSelection))
                    {
                        Console.WriteLine("Invalid Input. Please choose from 'check in', 'exit', or 'view bill'.");
                    } else
                    {
                        validInput = true;
                    }
                }
            } while (!validInput);
            return userSelection;
        }
        private static string IsPossibleCheckInOrBillOrExit(string userSelection)
        {
            string theUserSelection = "";
            bool isValidInput = false;
            int index = -1;
            try
            {
                isValidInput = Int32.TryParse(userSelection, out index);
                if (index == 1)
                {
                    theUserSelection = "check in";
                }
                else if (index == 2)
                {
                    theUserSelection = "view bill";
                }
                else if (index == 3)
                {
                    theUserSelection = "exit";
                }
            }
            catch (Exception e)
            {
                isValidInput = false;
            }
            return theUserSelection;
        }
        private static void CheckIn(string possibleClub, string nameInput, List<Club> clubs)
        {
            Member member = FindMember(nameInput, clubs);
            bool validInput = false;
            if (member is SingleClub)
            {
                member.CheckIn(member.MyClub);
            }
            else
            {
                do
                {
                    DisplayClubs(clubs);
                    Console.Write("Which club would you like to check in to? ");
                    possibleClub = Console.ReadLine().Trim().ToLower();
                    validInput = clubs.Select(club => club.Name.ToLower()).Contains(possibleClub);
                    if (!validInput)
                    {
                        possibleClub = IsPossibleClub(possibleClub, clubs);
                        if (possibleClub != "")
                        {
                            validInput = true;
                        }
                    }
                } while (!validInput);
                member.CheckIn(clubs.Where(club => club.Name.ToLower() == possibleClub).ToList()[0]);
            }
        }
        private static string IsPossibleClub(string possibleClub, List<Club> clubs)
        {
            string clubName = "";
            bool isValidInput = false;
            int index = -1;
            try
            {
                isValidInput = Int32.TryParse(possibleClub, out index);
                clubName = clubs[index - 1].Name.ToLower();
            }
            catch (Exception e)
            {
                isValidInput = false;
            }
            if (!isValidInput)
            {
                Console.WriteLine("Invalid Input. Please choose from one of the existing clubs above.");
            }
            return clubName;
        }
        private static string HandleClubType(string[] possibleClubs)
        {
            bool validInput = false;
            string clubType = "";
            do
            {
                Console.Write("Do you want to be a Single Club or Multi Club member? ");
                clubType = Console.ReadLine().Trim().ToLower();
                validInput = possibleClubs.Contains(clubType);
                if (!validInput)
                {
                    Console.WriteLine("Invalid Input. Please enter 'Single', 'Single Club', 'Multi', 'Multi Club'");
                }
            } while (!validInput);
            return clubType;
        }
        private static void DisplayClubs(List<Club> clubs)
        {
            Console.WriteLine("\nPossible Clubs:");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine($"| {"#",2} | {"Name",-25} | {"Address",-25} |");
            Console.WriteLine("------------------------------------------------------------");

            // Display club data
            for (int i = 0; i < clubs.Count; i++)
            {
                Console.WriteLine($"| {i + 1,2} | {clubs[i].Name,-25} | {clubs[i].Address,-25} |");
            }
            Console.WriteLine("------------------------------------------------------------");
        }
        private static void DisplayCheckInOrBillMenu()
        {
            Console.WriteLine("+----+------------+");
            Console.WriteLine($"| {"#",-2} | {"Options",-10}|");
            Console.WriteLine("+----+------------+");
            Console.WriteLine($"| {1,-2} | {"Check in",-10}|");
            Console.WriteLine($"| {2,-2} | {"View Bill",-10}|");
            Console.WriteLine($"| {3,-2} | {"Exit",-10}|");
            Console.WriteLine("+----+------------+");
            Console.Write("Please select from the following options above: ");
        }
    }
}
