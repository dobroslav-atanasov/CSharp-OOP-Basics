namespace Forum.App.UserInterface.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class ReplyViewModel
    {
        private const int LINE_LENGHT = 37;
        public ReplyViewModel()
        {
            throw new NotImplementedException();
        }


        public string Author { get; set; }

        public IList<string> Content { get; set; }

        private IList<string> GetLines(string content)
        {
            throw new NotImplementedException();
        }
    }
}