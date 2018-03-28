namespace Forum.App.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Enums;
    using Controllers;
    using Controllers.Contracts;
    using UserInterface;
    using UserInterface.Contracts;
    using Models;
    using Services;

    internal class MenuController
    {
        private const int DEFAULT_INDEX = 0;

        private IController[] controllers;
        private Stack<int> controllerHistory;
        private int currentOptionIndex;
        private ForumViewEngine forumViewer;

        public MenuController(IEnumerable<IController> controllers, ForumViewEngine forumViewer)
        {
            this.controllers = controllers.ToArray();
            this.forumViewer = forumViewer;

            this.InitializeControllerHistory();

            this.currentOptionIndex = DEFAULT_INDEX;
        }

        private string Username { get; set; }
        private IView CurrentView { get; set; }

        private MenuState State => (MenuState)this.controllerHistory.Peek();
        private int CurrentControllerIndex => this.controllerHistory.Peek();
        private IController CurrentController => this.controllers[this.controllerHistory.Peek()];
        internal ILabel CurrentLabel => this.CurrentView.Buttons[currentOptionIndex];

        private void InitializeControllerHistory()
        {
            if (controllerHistory != null)
            {
                throw new InvalidOperationException($"{nameof(controllerHistory)} already initialized!");
            }
            int mainControllerIndex = 0;
            this.controllerHistory = new Stack<int>();
            this.controllerHistory.Push(mainControllerIndex);
            this.RenderCurrentView();
        }

        internal void PreviousOption()
        {
            this.currentOptionIndex--;

            if (this.currentOptionIndex < 0)
            {
                this.currentOptionIndex += this.CurrentView.Buttons.Length;
            }

            if (this.CurrentLabel.IsHidden)
            {
                this.PreviousOption();
            }
        }

        internal void NextOption()
        {
            this.currentOptionIndex++;

            int totalOptions = this.CurrentView.Buttons.Length;

            if (this.currentOptionIndex >= totalOptions)
            {
                this.currentOptionIndex -= totalOptions;
            }

            if (this.CurrentLabel.IsHidden)
            {
                this.NextOption();
            }
        }

        internal void Back()
        {
            if (this.State == MenuState.Categories || this.State == MenuState.OpenCategory)
            {
                IPaginationController currentController = (IPaginationController)this.CurrentController;
                currentController.CurrentPage = 0;
            }

            if (controllerHistory.Count > 1)
            {
                controllerHistory.Pop();
                this.currentOptionIndex = DEFAULT_INDEX;
            }
            RenderCurrentView();
        }

        internal void ExecuteCommand()
        {
            MenuState newState = this.CurrentController.ExecuteCommand(currentOptionIndex);
            switch (newState)
            {
                case MenuState.PostAdded:
                    this.AddPost();
                    break;
                case MenuState.OpenCategory:
                    this.OpenCategory();
                    break;
                case MenuState.ViewPost:
                    this.ViewPost();
                    break;
                case MenuState.SuccessfulLogIn:
                    this.SuccessfulLogin();
                    break;
                case MenuState.LoggedOut:
                    this.LogOut();
                    break;
                case MenuState.Back:
                    this.Back();
                    break;
                case MenuState.Error:
                case MenuState.Rerender:
                    this.RenderCurrentView();
                    break;
                case MenuState.AddReplyToPost:
                    this.RedirectToAddReply();
                    break;
                case MenuState.ReplyAdded:
                    this.AddReply();
                    break;
                default:
                    this.RedirectToMenu(newState);
                    break;
            }
        }

        private void AddReply()
        {
            this.Back();
        }

        private void RedirectToAddReply()
        {
            PostDetailsController postDetailsController = (PostDetailsController)this.CurrentController;
            AddReplyController addReplyController = (AddReplyController)this.controllers[(int)MenuState.AddReply];
            addReplyController.SetPostId(postDetailsController.PostId);
            this.RedirectToMenu(MenuState.AddReply);
        }

        private void LogOut()
        {
            this.Username = string.Empty;
            this.LogOutUser();
            this.RenderCurrentView();
        }

        private void SuccessfulLogin()
        {
            IReadUserInfoController loginController = (IReadUserInfoController)this.CurrentController;
            this.Username = loginController.Username;

            this.LogInUser();
            this.RedirectToMenu(MenuState.Main);
        }

        private void ViewPost()
        {
            CategoryController categoryController = (CategoryController)this.CurrentController;
            int categoryId = categoryController.CategoryId;
            Post[] posts = PostService.GetPostsByCategory(categoryId).ToArray();

            int postIndex = categoryController.CurrentPage * CategoryController.PAGE_OFFSET + this.currentOptionIndex;
            int postId = posts[postIndex - 1].Id;

            PostDetailsController postController = (PostDetailsController)this.controllers[(int)MenuState.ViewPost];
            postController.SetPostId(postId);
            this.RedirectToMenu(MenuState.ViewPost);
        }

        private void OpenCategory()
        {
            CategoriesController categoriesController = (CategoriesController)this.CurrentController;
            int categoryIndex = categoriesController.CurrentPage * CategoriesController.PAGE_OFFSET +
                                this.currentOptionIndex;

            var categoryCtrlr = (CategoryController)this.controllers[(int)MenuState.OpenCategory];
            categoryCtrlr.SetCategory(categoryIndex);

            this.RedirectToMenu(MenuState.OpenCategory);
        }

        private void AddPost()
        {
            AddPostController addPostController = (AddPostController)this.CurrentController;

            int postId = addPostController.Post.PostId;
            PostDetailsController postViewer = (PostDetailsController)this.controllers[(int)MenuState.ViewPost];
            postViewer.SetPostId(postId);

            addPostController.ResetPost();
            this.controllerHistory.Pop();
            this.RedirectToMenu(MenuState.ViewPost);
        }

        private void RenderCurrentView()
        {
            this.CurrentView = this.CurrentController.GetView(this.Username);
            this.currentOptionIndex = DEFAULT_INDEX;
            this.forumViewer.RenderView(this.CurrentView);
        }

        private bool RedirectToMenu(MenuState newState)
        {
            if (this.State != newState)
            {
                this.controllerHistory.Push((int)newState);
                this.RenderCurrentView();
                return true;
            }
            return false;
        }

        private void LogInUser()
        {
            foreach (IController controller in this.controllers)
            {
                if (controller is IUserRestrictedController userRestrictedController)
                {
                    userRestrictedController.UserLogIn();
                }
            }
        }

        private void LogOutUser()
        {
            foreach (IController controller in this.controllers)
            {
                if (controller is IUserRestrictedController userRestrictedController)
                {
                    userRestrictedController.UserLogOut();
                }
            }
        }
    }
}