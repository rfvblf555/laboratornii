using EfCoreRelations.Entities;

namespace EfCoreRelations.Entities;

public class User
{
    public int Id { get; set; }
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string MiddleName { get; set; }
    public string Login { get; set; }
    public string Password { get; set; }
    public List<Role> Roles { get; set; }
    public List<Note> Notes { get; set; }

    public User()
    {
        Roles = new List<Role>();
        Notes = new List<Note>();
    }
    public User(string lastName, string firstName, string? middleName, string login, string password)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Login = login;
        Password = password;
        Roles = new List<Role>();
        Notes = new List<Note>();
    }
}
