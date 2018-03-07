namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class PostViewModel
    {
        private const int LINE_LENGHT = 37;

        public PostViewModel()
        {
            throw new NotImplementedException();
        }

        private IList<string> GetLines(string content)
        {
            throw new NotImplementedException();
        }

        public int PostId { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Category { get; set; }

        public IList<string> Content { get; set; }

        public IList<ReplyViewModel> Replies { get; set; }
    }
}
