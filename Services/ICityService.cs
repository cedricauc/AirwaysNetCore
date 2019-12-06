using Airways.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Airways.Services
{
    public interface ICityService
    {
        Task<IEnumerable<City>> All();
        Task<City> GetById(int Id);
    }
}