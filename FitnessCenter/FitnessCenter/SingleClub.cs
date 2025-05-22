namespace FitnessCenter;
/*
 * A child class of Member
 * Single Club Members: a variable that assigns them to a club.
   The CheckIn method throws an exception if it’s not their club.
 */

public class SingleClub: Member
{
    //assign user to club using string

    // Fields
    private string _clubName;

    // Constructors
    public SingleClub(string name, Club club) : base(name)
    {
        Name = name;
        _clubName = club.Name.ToLower();
        this.ClubName = this._clubName;
    }
    // Methods
    public override void CheckIn(Club club)
    {
        //check to see if the club name passed is = the club the SCM is assigned to.
        bool isValid = _clubName.Equals(club.Name.ToLower());
        //if the member isn't a member of the club name passed in, throw an exception.
         if (!isValid) throw new ArgumentException("You don't even go here!"); 
    }

}