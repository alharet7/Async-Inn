using Async_Inn.Models.DTO;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Security.Claims;

namespace Async_Inn.Models.Interfaces
{
    public interface IUser
    {
        public Task<UserDTO> Register(RegisterUserDTO registerUser, ModelStateDictionary modelState, ClaimsPrincipal claimsPrincipal);
        public Task<UserDTO> Authenticate(string username, string password);

        //----------------------------------- Lab 19 ----------------------------
        public Task<UserDTO> GetUser(ClaimsPrincipal principal);
    }
}