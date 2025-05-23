﻿namespace FitnessCenter;
/*
 * A provide a main class which takes input from the user:
   ○ Asks a user if they want to select a club
   ○ Added members should be given the option to select from at least 4 fitness center
   locations or have the option to be a multi-club member.
- Display a friendly error message if there is an exception. Don’t let it crash the program.
 */
class Program
{
    static void Main(string[] args)
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

        //program flow
        //ask the user for their name
        string nameInput;
        string clubType = "";
        string possibleClub = "";
        bool validInput = false;
        Console.WriteLine("\n Welcome to the Fitness Center\n");
        Console.Write("What is your Name? ");
        nameInput = Console.ReadLine();

        string[] possibleClubs = { "multi club", "multi", "single club", "single" };
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

        // instead of creating new array we created an array and casted it to a string[]
        if (((string[]) ["single", "single club"]).Contains(clubType))
        {
            do
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

                Console.Write("Please choose the club type you want to join: ");
                possibleClub = Console.ReadLine().Trim().ToLower();
                validInput = clubs.Select(club => club.Name.ToLower()).Contains(possibleClub);
                if (!validInput)
                {
                    int index = -1;
                    try
                    {
                        validInput = Int32.TryParse(possibleClub, out index);
                        possibleClub = clubs[index - 1].Name;
                    }
                    catch (Exception e) {
                        validInput = false;
                    }
                    if (!validInput)
                    {
                        Console.WriteLine("Invalid Input. Please choose from one of the existing clubs above.");
                    }
                }
            } while (!validInput);
            
            foreach (Club club in clubs)
            {
                if (club.Name == possibleClub)
                {
                    club.Members.Add(new SingleClub(nameInput,club));
                }
            }
        } else if (new string[] {"multi", "multi club" }.Contains(clubType))
        {
            foreach (Club club in clubs)
            {

                club.Members.Add(new MultiClub(nameInput));
            }
        }

        string userSelection;
        
        //REFACTOR --
            //nested do-while loops until user chooses to exit the program.
                //third option for exit?
        do
        {
            Console.Write("Would you like to check in or view your bill? ");
            userSelection = Console.ReadLine().Trim().ToLower();
            validInput = new string[] { "check in", "view bill", "bill" }.Contains(userSelection);
            if (!validInput)
            {
                Console.WriteLine("Invalid Input. Please choose from 'check in' or 'view bill'.");
            }
        } while (!validInput);
        if (userSelection == "check in")
        {
                Member member = FindMember(nameInput, clubs);
                if (member is SingleClub)
                {
                  member.CheckIn(member.MyClub);
                } else 
                {
                    do
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

                        Console.Write("Which club would you like to check in to?");
                        possibleClub = Console.ReadLine().Trim().ToLower();
                        validInput = clubs.Select(club => club.Name.ToLower()).Contains(possibleClub);
                        if (!validInput)
                        {
                            int index = -1;
                            try
                            {
                                validInput = Int32.TryParse(possibleClub, out index);
                                possibleClub = clubs[index - 1].Name;
                            }
                            catch (Exception e) {
                                validInput = false;
                            }
                            if (!validInput)
                            {
                                Console.WriteLine("Invalid Input. Please choose from one of the existing clubs above.");
                            }
                        }
                    } while (!validInput);
                    member.CheckIn(clubs.Where(club => club.Name == possibleClub).ToList()[0]);
                }

        } else if (userSelection == "view bill" || userSelection == "bill")
        {
           Console.Write(planetFitness.DisplayMember(FindMember(nameInput, clubs)));
        }
        
      
        
        



       //Console.WriteLine($"Welcome to Planet Fitness, ");

        /*PrintMovies(List<Club> clubs)
        {
            Console.WriteLine("\nMovies:");
            Console.WriteLine("-----------------------------------------------------------------");
            Console.WriteLine($"| {"Name",-25} | {"Category",-16} | {"Year",-2} | {"Run Time",-7}|");
            Console.WriteLine("-----------------------------------------------------------------");

            for (int i = 0; i < movies.Count; i++)
            {
                Console.WriteLine($"| {movies[i].Title,-25} | {movies[i].Category,-16} | {movies[i].YearReleased,2} | {movies[i].RunTime + " min",-7} |");
            }
            Console.WriteLine("-----------------------------------------------------------------");
    */
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
    
    
    
}