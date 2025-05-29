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

            
            bool running = true;
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
            
            do
            {
                userSelection = CheckOrBillOrExitValidation();
                if (userSelection == "check in")
                {
                    CheckIn(possibleClub, nameInput, clubs);
                }
                else if (userSelection == "view bill" || userSelection == "bill")
                {
                    Console.WriteLine(planetFitness.DisplayMember(FindMember(nameInput, clubs)));
                }
                else if (userSelection == "exit")
                {
                    SayGoodbye();
                    running = false;
                }
            } while (running);
        }
            
        //after prompting the user for their name, we ask them which member type they'd like to be.
            //if SingleClub member, display the list of club options.
        private static void DisplayClubs(List<Club> clubs)
        {
            Console.WriteLine("\nClubs:");
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
        
        //validate member type input provided by user
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

        ///// check in stuff /////
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
            Console.WriteLine("Thanks for checking in!");
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
        //validate, create, and add a SingleClub to a Club
        private static void HandleSingleClub(string nameInput, string possibleClub, List<Club> clubs)
        {
            bool validInput = false;
            do
            {
                DisplayClubs(clubs);
                Console.Write("Please choose the club you want to join: ");
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
        //validate, create, and add a MultiClub to a Club
        private static void HandleMultiClub(string nameInput, List<Club> clubs)
        {
            foreach (Club club in clubs)
            {

                club.Members.Add(new MultiClub(nameInput));
            }
        }
        ///// check in stuff /////

        //prompt the user to choose to check in, view their bill, or exit the program.
        private static string CheckOrBillOrExitValidation()
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
        
        ///// validation stuff /////
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
        ///// validation stuff /////

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
        //display cute goodbye message.
        private static void SayGoodbye()
        {
            string wave = "👋"; // Waving hand emoji (U+1F44B)
            string message = "Goodbye! See you soon!";

            Console.OutputEncoding = System.Text.Encoding.UTF8; // Ensure Unicode support
            // Print large hand (simulated with padding)
            Console.WriteLine("       " + wave);
            Console.WriteLine("      " + wave + wave);
            Console.WriteLine("     " + wave + wave + wave);
            Console.WriteLine("    " + wave + wave + wave + wave);
            Console.WriteLine("   " + wave + wave + wave + wave + wave);
            Console.WriteLine(message);
        }
    }
}
