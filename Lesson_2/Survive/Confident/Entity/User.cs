namespace Survive.Confident.Entity;

public class User
{
    private string Name { get; set; }
    private string Password { get; set; }

    public User(string name, string password)
    {
        Name = name;
        Password = password;
    }

    public string GetName()
    {
        return Name;
    }

    public string GetPassword()
    {
        return Password;
    }
}