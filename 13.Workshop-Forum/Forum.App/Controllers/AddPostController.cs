namespace Forum.App.Controllers
{
    using Enums;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;

    public class AddPostController : IController
    {
        private const int COMMAND_COUNT = 4;
        private const int TEXT_AREA_WIDTH = 37;
        private const int TEXT_AREA_HEIGHT = 18;
        private const int POST_MAX_LENGTH = 660;

        public MenuState ExecuteCommand(int index)
        {
            throw new System.NotImplementedException();
        }

        public IView GetView(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
