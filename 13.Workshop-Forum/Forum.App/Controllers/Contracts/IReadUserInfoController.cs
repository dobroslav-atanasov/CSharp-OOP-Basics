namespace Forum.App.Services.Contracts
{
    public interface IReadUserInfoController
    {
        void ReadUsername();

        void ReadPassword();

        string Username { get; }
    }
}