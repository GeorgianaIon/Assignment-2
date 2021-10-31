using System.Collections.Generic;
using System.Threading.Tasks;
using AdultsServer.Models;

namespace AdultsServer.Data
{
    public interface IAdultsService
    {
        Task<Adult> AddAdultsAsync(Adult adult);
        Task<IList<Adult>> GetAdultsAsync();
        Task RemoveAdultAsync(int AdultId);
    }
}