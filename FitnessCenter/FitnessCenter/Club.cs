using System.Diagnostics.CodeAnalysis;

namespace FitnessCenter;

/*
 * A Club class that holds basic details about each fitness club, including at minimum:
   ○    name || DONE
   ○    address || DONE
   ○    anything else you think might be useful
   ● Allow users to:
   ○      Add members (both kinds), remove members or display member information. || DONE
          Check a particular member in at a particular club. (Call the CheckIn method).
          Select a member and generate a bill of fees. Include membership points for
        Multi-Club Members.
 */
public class Club
{
    // Fields
    private string _address;

    //Constr
    public Club(string name, string address)
    {
        Name = name;
        _address = address;
        const decimal feeAmt = 0.50m;
    }
    
    // Properties 
    public List<Member> Members = new List<Member>();
    public string Name { get; }
    //default amount for entry fee is zero.
    public decimal Fee { get; } = 0;

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
        return displayString;
    }
}

