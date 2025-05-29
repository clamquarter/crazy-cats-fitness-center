namespace FitnessCenter;

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
        this.BillableAmount += club.FeeAmt;

    }

}