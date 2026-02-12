
namespace Application.DTOs.Response
{
    public record LoginResponse(bool Flag = false, string Message = null!, string Token = null!, string RefreshToken = null!)
    {
        public bool IsSuccess { get; internal set; }
    }
}
