using System.Diagnostics.CodeAnalysis;

namespace FitnessCenter;
public class Club
{

    //Constructors
    public Club(string name, string address)
    {
        Name = name;
        Address = address;
    }
    
    // Properties 
    public List<Member> Members = new List<Member>();
    public string Name { get; }
    public string Address { get; }
    //default amount for entry fee is 50 cents.
    public decimal FeeAmt = 0.50m;

    // Methods 
    public void AddMember(Member member)
    {
        Members.Add(member);
    }
    public void RemoveMember(Member member)
    {
        Members.Remove(member);
    }
    
    public string DisplayMember(Member member)
    {
        string displayString;
        if (member is SingleClub)
        {
            displayString = $"{member.Name} is a Single-club member and joined the {member.ClubName} club.";
        }
        else {
            displayString = $"{member.Name} is a Multi-club member and has a total of {member.MemberShipPoints} points.";
        }

        displayString += $" {member.Name} owes ${member.BillableAmount}.";
        return displayString;
    }
}

