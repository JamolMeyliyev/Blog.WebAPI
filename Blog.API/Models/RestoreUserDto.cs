namespace Blog.API.Models
{
    public class RestoreUserDto
    {
         public required string UserName { get; set; }
         public required string Password { get; set; }
         public required string Email { get; set; }

    }
}
