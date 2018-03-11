namespace Forum.App.Controllers
{
    using Enums;
    using Exceptions;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Services;
    using UserInterface;
    using UserInterface.ViewModels;
    using Views;


    public class PostDetailsController : IController, IUserRestrictedController
    {
        public bool LoggedInUser { get; set; }

        public int PostId { get; private set; }

        private enum Command
        {
            Back,
            AddReply,
        }

        public MenuState ExecuteCommand(int index)
        {
            switch ((Command) index)
            {
                case Command.AddReply:
                    return MenuState.AddReplyToPost;
                case Command.Back:
                    ForumViewEngine.ResetBuffer();
                    return MenuState.Back;
                default:
                    throw new InvalidCommandException();
            }
        }

        public IView GetView(string userName)
        {
            PostViewModel pvm = PostService.GetPostViewModel(this.PostId);
            return new PostDetailsView(pvm, this.LoggedInUser);
        }

        public void UserLogIn()
        {
            this.LoggedInUser = true;
        }

        public void UserLogOut()
        {
            this.LoggedInUser = false;
        }

        public void SetPostId(int postId)
        {
            this.PostId = postId;
        }
    }
}