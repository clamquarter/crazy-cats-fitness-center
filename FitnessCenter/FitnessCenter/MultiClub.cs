namespace FitnessCenter;
/*
 * A child class of Member
 * Multi-Club
   Members (these members can visit various locations using the same membership).
  
 * Multi-Club Members: a variable that stores their membership points.
   The CheckIn method adds to their membership points.
   
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
    public override void CheckIn(string club)
    {
        this._memberShipPoints += 20;
        this.MemberShipPoints = this._memberShipPoints;
    }

}