namespace Forum.App.Services.Contracts
{
    public interface IUserRestrictedController
    {
        bool LoggedInUser { get; }

        void UserLogIn();

        void UserLogOut();
    }
}