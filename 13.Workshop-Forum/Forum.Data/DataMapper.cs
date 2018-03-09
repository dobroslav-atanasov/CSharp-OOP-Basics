namespace Forum.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Models;

    public class DataMapper
    {
        private const string DATA_PATH = "../data/";
        private const string CONFIG_PATH = "config.ini";
        private const string DEFAULT_CONFIG = "users=users.csv\r\ncategories=categories.csv\r\nposts=posts.csv\r\nreplies=replies.csv";
        private static readonly Dictionary<string, string> config;

        static DataMapper()
        {
            Directory.CreateDirectory(DATA_PATH);
            config = LoadConfig(DATA_PATH + CONFIG_PATH);
        }

        private static void EnsureConfigFile(string configPath)
        {
            if (!File.Exists(configPath))
            {
                File.WriteAllText(configPath, DEFAULT_CONFIG);
            }
        }

        private static void EnsureFile(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        private static Dictionary<string, string> LoadConfig(string configPath)
        {
            EnsureConfigFile(configPath);

            string[] contents = ReadLines(configPath);

            Dictionary<string, string> config = contents
                .Select(line => line.Split('='))
                .ToDictionary(x => x[0], x => DATA_PATH + x[1]);

            return config;
        }

        private static string[] ReadLines(string path)
        {
            EnsureFile(path);
            string[] lines = File.ReadAllLines(path);
            return lines;
        }

        private static void WriteLines(string path, string[] lines)
        {
            File.WriteAllLines(path, lines);
        }

        public static List<Category> LoadCategories()
        {
            List<Category> categories = new List<Category>();
            string[] dataLines = ReadLines(config["categories"]);

            foreach (string line in dataLines)
            {
                string[] parts = line.Split(";");
                int id = int.Parse(parts[0]);
                string name = parts[1];
                var postIds = parts[2]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();
                Category category = new Category(id, name, postIds);
                categories.Add(category);
            }

            return categories;
        }

        public static List<User> LoadUsers()
        {
            List<User> users = new List<User>();
            string[] dataLines = ReadLines(config["users"]);

            foreach (string line in dataLines)
            {
                string[] parts = line.Split(";");
                int id = int.Parse(parts[0]);
                string username = parts[1];
                string password = parts[2];
                int[] postIds = parts[3]
                    .Split(new []{','}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                User user = new User(id, username, password, postIds);
                users.Add(user);
            }

            return users;
        }

        public static List<Post> LoadPosts()
        {
            List<Post> posts = new List<Post>();
            string[] dataLines = ReadLines(config["posts"]);

            foreach (string line in dataLines)
            {
                string[] parts = line.Split(";");
                int id = int.Parse(parts[0]);
                string title = parts[1];
                string content = parts[2];
                int categoryId = int.Parse(parts[3]);
                int authorId = int.Parse(parts[4]);
                int[] replyIds = parts[5]
                    .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                Post post = new Post(id, title, content, categoryId, authorId, replyIds);
                posts.Add(post);
            }

            return posts;
        }

        public static List<Reply> LoadReplies()
        {
            List<Reply> replies = new List<Reply>();
            string[] dataLines = ReadLines(config["replies"]);

            foreach (string line in dataLines)
            {
                string[] parts = line.Split(";");
                int id = int.Parse(parts[0]);
                string content = parts[1];
                int authorId = int.Parse(parts[2]);
                int postId = int.Parse(parts[3]);
                Reply reply = new Reply(id, content, authorId, postId);
                replies.Add(reply);
            }

            return replies;
        }

        public static void SaveCategories(List<Category> categories)
        {
            List<string> lines = new List<string>();

            foreach (Category category in categories)
            {
                const string categoryFormat = "{0};{1};{2};";
                string line = string.Format(categoryFormat, category.Id, category.Name, string.Join(",", category.PostIds));
                lines.Add(line);
            }

            WriteLines(config["categories"], lines.ToArray());
        }

        public static void SaveUsers(List<User> users)
        {
            List<string> lines = new List<string>();

            foreach (User user in users)
            {
                const string userFormat = "{0};{1};{2};";
                string line = string.Format(userFormat, user.Id, user.Username, user.Password);
                lines.Add(line);
            }

            WriteLines(config["users"], lines.ToArray());
        }

        public static void SavePosts(List<Post> posts)
        {
            List<string> lines = new List<string>();

            foreach (Post post in posts)
            {
                const string postFormat = "{0};{1};{2};{3};{4};{5};";
                string line = string.Format(postFormat, post.Id, post.Title, post.Content, post.CategoryId,
                    post.AuthorId, string.Join(",", post.ReplyIds));
                lines.Add(line);
            }

            WriteLines(config["posts"], lines.ToArray());
        }

        public static void SaveReplies(List<Reply> replies)
        {
            List<string> lines = new List<string>();

            foreach (Reply reply in replies)
            {
                const string replyFormat = "{0};{1};{2};{3};";
                string line = string.Format(replyFormat, reply.Id, reply.Content, reply.AuthorId, reply.PostId);
                lines.Add(line);
            }

            WriteLines(config["replies"], lines.ToArray());
        }
    }
}