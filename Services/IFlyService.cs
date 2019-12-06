using Airways.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airways.Services
{
    public interface IFlyService
    {
        Task<Fly> Add(Fly flyModel);
        Task<IEnumerable<Fly>> All();
        Task<Fly> GetById(int id);
        Task Update(Fly flyModel);
        Task Delete(int id);
    }
}