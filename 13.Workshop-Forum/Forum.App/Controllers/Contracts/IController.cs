namespace Forum.App.Services.Contracts
{
    using Forum.App.UserInterface.Contracts;
    using Forum.App.Enums;

    public interface IController
    {
        MenuState ExecuteCommand(int index);

        IView GetView(string userName);
    }
}