namespace Forum.App.Controllers
{
    using System;
    using System.Linq;
    using Enums;
    using Exceptions;
    using Forum.App.Controllers.Contracts;
    using Forum.App.UserInterface.Contracts;
    using Services;
    using Views;

    public class CategoryController : IController, IPaginationController
    {
        public const int PAGE_OFFSET = 10;
        private const int COMMAND_COUNT = PAGE_OFFSET + 3;

        public CategoryController()
        {
            this.CurrentPage = 0;
            this.SetCategory(0);
        }

        public int CurrentPage { get; set; }

        private string[] PostTitles { get; set; }

        private int LastPage => this.PostTitles.Length / 11;

        private bool IsFirstPage => this.CurrentPage == 0;

        private bool IsLastPage => this.CurrentPage == this.LastPage;

        public int CategoryId { get; private set; }

        private enum Command
        {
            Back = 0,
            ViewPost = 1,
            PreviousPage = 11,
            NextPage = 12,
        }

        public MenuState ExecuteCommand(int index)
        {
            if (index > 1 && index < 11)
            {
                index = 1;
            }

            switch ((Command) index)
            {
                case Command.Back:
                    return MenuState.Back;
                case Command.ViewPost:
                    return MenuState.ViewPost;
                case Command.PreviousPage:
                    this.ChangePage(false);
                    return MenuState.OpenCategory;
                case Command.NextPage:
                    this.ChangePage();
                    return MenuState.OpenCategory;
                default:
                    throw new InvalidCommandException();
            }
        }

        public IView GetView(string userName)
        {
            this.GetPost();
            string categoryName = PostService.GetCategory(this.CategoryId).Name;
            return new CategoryView(categoryName, this.PostTitles, this.IsFirstPage, this.IsLastPage);
        }

        public void SetCategory(int categoryId)
        {
            this.CategoryId = categoryId;
        }

        private void ChangePage(bool forward = true)
        {
            this.CurrentPage += forward ? 1 : -1;
            this.GetPost();
        }

        private void GetPost()
        {
            var allCategoryPosts = PostService.GetPostsByCategory(this.CategoryId);
            this.PostTitles = allCategoryPosts
                .Skip(this.CurrentPage * PAGE_OFFSET)
                .Take(PAGE_OFFSET)
                .Select(p => p.Title)
                .ToArray();
        }
    }
}