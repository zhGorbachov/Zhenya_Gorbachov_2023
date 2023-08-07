using Survive.Confident.Entity;
using Survive.Confident.Interface;

namespace Survive.Confident.Service;

public class UserService : IUserService
{
    private List<User> Users { get; set; }
    
    public void RegisterUser(string name, string password)
    {
        if (CheckUser(name))
        {
            var user = new User(name, password);
            Users.Add(user);
            Console.WriteLine("User is registered.");
        }
        else
        {
            Console.WriteLine($"This username: {name} is taken.");
        }
    }

    public void EnterInUser(string name, string password)
    {
        var user = Users.Any(x => x.GetName() == name && x.GetPassword() == password);
        if (user)
        {
            Console.WriteLine("You have entered the user");
        }
        else
        {
            Console.WriteLine("Your user has benn lohed");
        }
    }

    public bool CheckUser(string name)
    {
        return Users.Any(x => x.GetName() == name);
    }
}