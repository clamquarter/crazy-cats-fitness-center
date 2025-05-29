namespace FitnessCenter;

public class SingleClub: Member
{
    // Fields
    private string _clubName;

    // Constructors
    public SingleClub(string name, Club club) : base(name)
    {
        Name = name;
        _clubName = club.Name.ToLower();
        this.ClubName = this._clubName;
        this.MyClub = club;
    }
    
    // Properties
    //during development, the team mistakenly declared a property in both a child and parent class.
    //public Club MyClub { get; set; }
    
    // Methods
    public override void CheckIn(Club club)
    {
        //check to see if the club name passed is = the club the SCM is assigned to.
        bool isValid = MyClub.Name.ToLower().Equals(club.Name.ToLower());
        //if the member isn't a member of the club name passed in, throw an exception.
         if (!isValid) throw new ArgumentException("You don't even go here!");
        this.BillableAmount += club.FeeAmt;
    }

}