namespace Blog.API.Entities
{
    public class User
    {
        public Guid Id { get; set; }
        public required string Username { get; set; }
        public required string Name { get; set; }
        public string PasswordHash { get; set; }
        public required string Email { get; set; }
        public required bool IsDeleted { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public List<Blog>? Blogs { get; set; }
        public List<SaveMessage>? Saves { get; set; }
    }
}
