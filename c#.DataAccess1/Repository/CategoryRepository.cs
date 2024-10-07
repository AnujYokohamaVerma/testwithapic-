using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_.DataAccess1.Repository.IRepository;
using testwithapic_.Data;
using testwithapic_.Models;

namespace c_.DataAccess1.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void update(Category obj)
        {
            _db.Categoryies.Update(obj);
        }
    }
}
