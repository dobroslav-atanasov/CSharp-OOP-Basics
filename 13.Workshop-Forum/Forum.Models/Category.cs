namespace Forum.Models
{
    using System.Collections.Generic;

    public class Category
    {
        public Category(int id, string name, IEnumerable<int> postIds)
        {
            this.Id = id;
            this.Name = name;
            this.PostIds = new List<int>(postIds);
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<int> PostIds { get; set; }
    }
}
