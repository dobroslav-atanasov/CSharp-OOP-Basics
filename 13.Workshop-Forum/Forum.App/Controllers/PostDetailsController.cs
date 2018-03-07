namespace Forum.App.Controllers
{
    using Enums;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;


    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser => throw new System.NotImplementedException();

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new System.NotImplementedException();
        }

        public void UserLogIn()
        {
            throw new System.NotImplementedException();
        }

        public void UserLogOut()
        {
            throw new System.NotImplementedException();
        }
    }
}
