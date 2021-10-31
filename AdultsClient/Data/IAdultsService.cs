using System.Collections.Generic;
using System.Threading.Tasks;
using AdultsClient.Models;

namespace AdultsClient.Data
{
    public interface IAdultsService
    {
        Task AddAdultsAsync(Adult adult);
        Task<IList<Adult>> GetAdultsAsync();
        Task RemoveAdultAsync(int AdultId);
    }
}