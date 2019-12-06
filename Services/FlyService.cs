using Airways.Data;
using Airways.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Airways.Services
{
    public class FlyService : IFlyService
    {
        private readonly ILogger _logger;
        DbContextOptions<ApplicationDbContext> _dbContextOptions;

        public FlyService(ILogger<FlyService> logger, DbContextOptions<ApplicationDbContext> dbContextOptions)
        {
            _logger = logger;
            _dbContextOptions = dbContextOptions;
        }

        public async Task<IEnumerable<Fly>> All()
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                return dbContext.Set<Fly>().OrderBy(a => a.Id).ToList();
            }
        }

        public async Task<Fly> GetById(int id)
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                return dbContext.Set<Fly>().FirstOrDefault(x => x.Id == id);
            }
        }

        public async Task<Fly> Add(Fly flyModel)
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                dbContext.Add(flyModel);
                dbContext.SaveChanges();
                return await Task.FromResult(flyModel);
            }
        }

        public Task Update(Fly flyModel)
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                dbContext.Update(flyModel);
                dbContext.SaveChanges();
                return Task.CompletedTask;
            }
        }

        public Task Delete(int id)
        {
            using (var dbContext = new ApplicationDbContext(_dbContextOptions))
            {
                dbContext.Remove(dbContext.FlyModels.Single(a => a.Id == id));
                dbContext.SaveChanges();
                return Task.CompletedTask;
            }
        }
    }
}
