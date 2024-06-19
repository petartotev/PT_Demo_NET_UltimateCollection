namespace Personal.General.Hash.Models;

public class PersonHashOverridden
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string Email { get; set; }

    public override int GetHashCode()
    {
        /* Implementation by ChatGPT */
        //int hash = 17;
        //hash = hash * 23 + (FirstName != null ? FirstName.GetHashCode() : 0);
        //hash = hash * 23 + (LastName != null ? LastName.GetHashCode() : 0);
        //hash = hash * 23 + DateOfBirth.GetHashCode();
        //hash = hash * 23 + (Email != null ? Email.GetHashCode() : 0);
        //return hash;

        /* Implementation by VisualStudio suggestion */
        return HashCode.Combine(FirstName, LastName, DateOfBirth, Email);
    }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        PersonHashOverridden other = (PersonHashOverridden)obj;

        return FirstName == other.FirstName &&
               LastName == other.LastName &&
               DateOfBirth == other.DateOfBirth &&
               Email == other.Email;
    }
}
