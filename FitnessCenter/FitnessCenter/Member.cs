namespace FitnessCenter;
/*
 * A class to hold basic details about Members (this class should eventually have at least 2
   child classes) and hold the following details at a minimum:
   ○ id, name
   ○ an abstract method void CheckIn(Club club)
 */
public abstract class Member
{ 
  
  //Contr
  public Member(string name)
  {
    Random random = new Random();
    Name = name;
    //0 - number randomized
    /*
     * List of Members
     * Check .Contains ID
     * Go do/while loop to check preexisting memeber IDS
     */
    Id = random.Next();
  }


  //Properties
  public int Id { get;}
  public string Name {get;}
  
  
//Methods
  public abstract void CheckIn(Club club);

}