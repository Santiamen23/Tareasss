using BooksTW.Models.Dtos;

namespace BooksTW.Services
{
    public interface IAuthService
    {
        Task<string> register(RegisterDto dto);
        Task<(bool ok, LoginResponseDto? response)> login(LoginDto dto);

        Task<(bool ok, LoginResponseDto? response)> refresh(RefreshRequestDto dto);
    }
}
