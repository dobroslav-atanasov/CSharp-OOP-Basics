namespace Forum.Models
{
    using System.Collections.Generic;

    public class User
    {
        public User(int id, string username, string password)
        {
            this.Id = id;
            this.Username = username;
            this.Password = password;
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }
    }
}
