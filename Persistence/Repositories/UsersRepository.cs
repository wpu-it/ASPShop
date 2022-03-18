using Domain.Entities;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Persistence.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        ApplicationContext db;
        DbSet<User> Table => db.Set<User>();
        public UsersRepository(ApplicationContext db)
        {
            this.db = db;
        }
        public async Task<User> Get(string id)
        {
            return await Table.Include(us => us.Products).Include(us => us.Orders).FirstOrDefaultAsync(us => us.Id == id); 
        }
    }
}
