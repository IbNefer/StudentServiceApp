
namespace Application.DTOs.Request.Account
{
    public class ChangeUserRoleRequestDTO(string UserEmail, string NewRole)
    {
        public string NewRole { get; set; }
        public string Email { get; set; }
    }
}
