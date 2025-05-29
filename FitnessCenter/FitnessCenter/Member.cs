namespace FitnessCenter;

public abstract class Member
{ 
  //Constructors
  public Member(string name)
  {
    //using Random() ensures the Id will be unique.
    Random random = new Random();
    
    //keep creating a new Id using random.Next(), as long as the Id exists in existing Ids
    do
    {
      Id = random.Next(2147483647);
      
    } while (ExistingIds.Contains(Id));
    
    //add the Id to the List of Ids
    ExistingIds.Add(Id);
    
    Name = name;
    
  }
  
  //Properties
  public int Id { get;}
  public string Name {get; set; }
    public string ClubName { get; set; }
    public int MemberShipPoints { get; set; }
    public decimal BillableAmount { get; set; } = 0;
    protected static List<int> ExistingIds { get; } = new List<int>();
    
    public Club MyClub { get; set; }
    
    //Methods
    public abstract void CheckIn(Club club);
    
}