namespace LINQ_Demo;

public class Person
{
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public string FullName => $"{LastName} {FirstName}";
    
    public DateTime DateOfBirth { get; init; }
    public int Age {
        get
        {
            var now = DateTime.Today;
            return now.Year - DateOfBirth.Year - 1 + ((now.Month > DateOfBirth.Month || now.Month == DateOfBirth.Month && now.Day >= DateOfBirth.Day) ? 1 : 0);
        }
    }
}