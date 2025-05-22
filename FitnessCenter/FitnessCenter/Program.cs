namespace FitnessCenter;
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
        //ask the user ot choose a membership level (Single or Multi)
        //if Single, ask the user to choose a club
        //initialize a SingleClub or MultiClub based on user choice
        //add the Member to the club they picked
        //add MultiClub to all clubs available

        //laFitness.CheckIn(india);

        //display available clubs & prices
        foreach (Club club in clubs)
        {
            Console.WriteLine(club.Name);
        }

        Console.WriteLine($"There are {clubs.Count} clubs available. Would you like to be a single or multi-club member?");
       // Console.ReadLine();
       
       // //TEST CODE
       //  planetFitness.AddMember(india);
       //  Console.Write($"PF has {planetFitness.Members.Count} members.");
       //  india.CheckIn(planetFitness);
       // Console.WriteLine(planetFitness.DisplayMember(india));
       // Console.WriteLine(planetFitness.DisplayMember(youssef));
       // planetFitness.RemoveMember(india);
       // Console.Write($"PF has {planetFitness.Members.Count} members.");




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
}