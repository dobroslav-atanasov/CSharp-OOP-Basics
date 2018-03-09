namespace Forum.App.Controllers
{
    using System;
    using Enums;
    using Forum.App;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Services;
    using UserInterface;

    public class SignUpController : IController, IReadUserInfoController
    {
        private const string DETAILS_ERROR = "Invalid Username or Password!";
        private const string USERNAME_TAKEN_ERROR = "Username already in use!";

        public string Username { get; private set; }

        private string Password { get; set; }

        private string ErrorMessage { get; set; }

        private enum Command
        {
            ReadUsername,
            ReadPassword,
            SignUp,
            Back,
        }
        
        public MenuState ExecuteCommand(int index)
        {
            switch ((Command)index)
            {
                case Command.ReadUsername:
                    this.ReadUsername();
                    return MenuState.Signup;
                case Command.ReadPassword:
                    this.ReadPassword();
                    return MenuState.Signup;
                case Command.SignUp:
                    SignUpStatus signUp = UserService.TrySignUpUser(this.Username, this.Password);
                    switch (signUp)
                    {
                        case SignUpStatus.Success:
                            return MenuState.SuccessfulLogIn;
                        case SignUpStatus.DetailsError:
                            this.ErrorMessage = DETAILS_ERROR;
                            return MenuState.Error;
                        case SignUpStatus.UsernameTakenError:
                            this.ErrorMessage = USERNAME_TAKEN_ERROR;
                            return MenuState.Error;
                    }
                    return MenuState.Error;
                case Command.Back:
                    this.ResetSignUp();
                    return MenuState.Back;
                default:
                    throw new InvalidOperationException();
            }
        }

        public IView GetView(string userName)
        {
            return new SignUpView(this.ErrorMessage);
        }

        public void ReadPassword()
        {
            this.Password = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        public void ReadUsername()
        {
            this.Username = ForumViewEngine.ReadRow();
            ForumViewEngine.HideCursor();
        }

        private void ResetSignUp()
        {
            this.ErrorMessage = string.Empty;
            this.Username = string.Empty;
            this.Password = string.Empty;
        }
    }
}
