using System.Threading.Tasks;
using AdultsServer.Models;

namespace AdultsServer.Data
{
    public interface IUserService
    {
        Task<User> ValidateUser(string userName, string password);
    }
}