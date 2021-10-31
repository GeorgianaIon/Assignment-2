using System.Threading.Tasks;
using AdultsClient.Models;

namespace AdultsClient.Data
{
    public interface IUserService
    {
        Task<User> ValidateUserAsync(string userName, string password);
    }
}