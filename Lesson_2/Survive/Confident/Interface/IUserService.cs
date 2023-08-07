namespace Survive.Confident.Interface;

public interface IUserService
{
    public void RegisterUser(string name, string password);
    public void EnterInUser(string name, string password);
    public bool CheckUser(string name);
}