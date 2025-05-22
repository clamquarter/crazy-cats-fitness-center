using System.Diagnostics.CodeAnalysis;

namespace FitnessCenter;

/*
 * A Club class that holds basic details about each fitness club, including at minimum:
   ○    name
   ○    address
   ○    anything else you think might be useful
   ● Allow users to:
   ○      Add members (both kinds), remove members or display member information.
          Check a particular member in at a particular club. (Call the CheckIn method).
          Select a member and generate a bill of fees. Include membership points for
   Multi-Club Members.
 */
public class Club
{
    // Fields
    private string _name;
    private string _address;

    // Properties 
    public static List<Member> Members = new List<Member>();
    // Methods 
    public static void RemoveMember(Member member)
    {
        Members = Members.Where(aMember => aMember.Id == member.Id).ToList();
    }
    public static string DisplayMember(Member member)
    {
        string displayString = "";
        if (member is SingleClub)
        {
            displayString = $"{member.Name} is a Single club member and joined the {member.ClubName} club";
        }
        else if (member is MultiClub) {
            displayString = $"{member.Name} is a Multi club member and has a total of {member.MemberShipPoints}";
        }
        return displayString;
    }
}