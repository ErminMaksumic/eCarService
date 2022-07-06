using eCarService.Database;
using Microsoft.EntityFrameworkCore;

namespace eCarService.DbSeed
{
    public class DbSeed
    {
        public void Init(eCarServiceContext context)
        {
            context.Database.Migrate();
        }

        public void InsertData(eCarServiceContext context)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "DbSeed", "db.sql");
            var query = File.ReadAllText(path);
            context.Database.ExecuteSqlRaw(query);
        }
    }
}
