using Airways.Data;
using Airways.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airways.Services
{
    public class CityService : ICityService
    {
        private readonly ILogger _logger;
        DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public CityService(ILogger<CityService> logger, DbContextOptions<ApplicationDbContext> dbContextOptions)
        {
            _logger = logger;
            _dbContextOptions = dbContextOptions;
        }

        public async Task<IEnumerable<City>> All()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                return dbContext.Set<City>().OrderBy(a => a.Id).ToList();
            }
        }

        public async Task<City> GetById(int Id)
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                return dbContext.Set<City>().FirstOrDefault(x => x.Id == Id);
            }
        }
    }
}
