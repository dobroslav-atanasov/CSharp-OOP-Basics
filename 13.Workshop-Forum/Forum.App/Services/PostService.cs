namespace Forum.App.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using Data;
    using Models;
    using UserInterface.ViewModels;

    public static class PostService
    {
        internal static Category GetCategory(int categoryId)
        {
            ForumData forumData = new ForumData();
            Category category = forumData.Categories.Find(c => c.Id == categoryId);
            return category;
        }

        internal static IList<ReplyViewModel> GetPostReplies(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(p => p.Id == postId);
            IList<ReplyViewModel> replies = new List<ReplyViewModel>();

            foreach (int replyId in post.Replies)
            {
                Reply reply = forumData.Replies.Find(r => r.Id == replyId);
                replies.Add(new ReplyViewModel(reply));
            }

            return replies;
        }

        internal static string[] GetAllCategoryNames()
        {
            ForumData forumData = new ForumData();
            string[] allCategories = forumData.Categories.Select(c => c.Name).ToArray();
            return allCategories;
        }

        public static IEnumerable<Post> GetPostsByCategory(int categoryId)
        {
            ForumData forumData = new ForumData();
            ICollection<int> postIds = forumData.Categories.First(c => c.Id == categoryId).PostIds;
            IEnumerable<Post> posts = forumData.Posts.Where(p => postIds.Contains(p.Id));
            return posts;
        }

        public static PostViewModel GetPostViewModel(int postId)
        {
            ForumData forumData = new ForumData();
            Post post = forumData.Posts.Find(p => p.Id == postId);
            PostViewModel pvm = new PostViewModel(post);
            return pvm;
        }

        private static Category EnsureCategory(PostViewModel pvm, ForumData forumData)
        {
            string categoryName = pvm.Category;
            Category category = forumData.Categories.FirstOrDefault(c => c.Name == categoryName);
            if (category == null)
            {
                List<Category> categories = forumData.Categories;
                int categoryId = categories.Any() ? categories.Last().Id + 1 : 1;
                category = new Category(categoryId, categoryName, new List<int>());
                forumData.Categories.Add(category);
            }
            return category;
        }

        public static bool TrySavePost(PostViewModel pvm)
        {
            bool emptyCategory = string.IsNullOrWhiteSpace(pvm.Category);
            bool emptyTitle = string.IsNullOrWhiteSpace(pvm.Title);
            bool emptyContent = !pvm.Content.Any();

            if (emptyCategory || emptyTitle || emptyContent)
            {
                return false;
            }

            ForumData forumData = new ForumData();
            Category category = EnsureCategory(pvm, forumData);

            int postId = forumData.Posts.Any() ? forumData.Posts.LastOrDefault().Id + 1 : 1;
            User author = forumData.Users.Single(u => u.Username == pvm.Author);
            int authorId = author.Id;
            string content = string.Join("", pvm.Content);

            Post post = new Post(postId, pvm.Title, content, category.Id, authorId, new List<int>());

            forumData.Posts.Add(post);
            author.PostIds.Add(post.Id);
            category.PostIds.Add(post.Id);
            forumData.SaveChanges();
            pvm.PostId = postId;
            return true;
        }

        public static bool TrySaveReply(ReplyViewModel rvm, int postId)
        {
            if (!rvm.Content.Any())
            {
                return false;
            }
            
            ForumData forumData = new ForumData();
            User author = UserService.GetUser(rvm.Author);
            int authorId = author.Id;
            Post post = forumData.Posts.Single(p => p.Id == postId);
            int replyId = forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            string content = string.Join("", rvm.Content);

            Reply reply = new Reply(replyId, content, authorId, postId);

            forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            forumData.SaveChanges();
            return true;
        }
    }
}