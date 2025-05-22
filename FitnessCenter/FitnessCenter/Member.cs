namespace FitnessCenter;
/*
 * A class to hold basic details about Members (this class should eventually have at least 2
   child classes) and hold the following details at a minimum:
   ○ id, name
   ○ an abstract method void CheckIn(Club club)
 */
public abstract class Member
{ 
  //initialize a protected static (must be unique) List of existing Ids.
  
  //Constructors
  public Member(string name)
  {
    Random random = new Random();
    
    //keep creating a new Id using random.Next(), as long as the Id exists in existing Ids
    do
    {
      Id = random.Next(2147483647);
      
    } while (ExistingIds.Contains(Id));
    
    //add the Id to the List of Ids
    ExistingIds.Add(Id);
    Name = name;
    //0 - number randomized
    /*
     * List of Members
     * Check .Contains ID
     * Go do/while loop to check preexisting member IDS
     */
  }


  //Properties
  public int Id { get;}
  public string Name {get; set; }
    public string ClubName { get; set; }
    public int MemberShipPoints { get; set; }
    protected static List<int> ExistingIds { get; } = new List<int>();

    //Methods
    public abstract void CheckIn(string club);

}