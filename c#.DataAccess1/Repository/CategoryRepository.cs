using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo.DataAccess1.Repository.IRepository;
using Apollo.DataAccess1.Data;
using ApolloWeb.Models;

namespace Apollo.DataAccess1.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void update(Category obj)
        {
            _db.Categoryies.Update(obj);
        }
    }
}
