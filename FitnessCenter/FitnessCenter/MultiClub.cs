namespace FitnessCenter;
/*
 * A child class of Member
 * Multi-Club
   Members (these members can visit various locations using the same membership).
  
 * Multi-Club Members: a variable that stores their membership points. || DONE
   The CheckIn method adds to their membership points. || DONE
   
 */

public class MultiClub: Member
{
    // Fields
    private int _memberShipPoints = 0;
    // Constructors
    public MultiClub(string name) : base(name)
    {
        Name = name;
    }

    // Methods
    public override void CheckIn(Club club)
    {
        //add 20 and update memberShipPoints on check in.
        this._memberShipPoints += 20;
        //allows DisplayClub to reference the membershipPoints (exclusive to MultiClub members)
        this.MemberShipPoints = this._memberShipPoints;
    }

}