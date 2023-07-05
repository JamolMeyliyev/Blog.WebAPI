namespace Blog.API.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        
        public required string Username { get; set; }
        public required string Email { get; set; }
        public required bool IsDeleted { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTime.UtcNow;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
