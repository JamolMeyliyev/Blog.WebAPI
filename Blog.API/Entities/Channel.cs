namespace Blog.API.Entities
{
    public class Channel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public bool IsDeleted { get; set; }
        public List<User> Users { get; set; }
        public List<Post> Posts { get; set; }
    }
}
