using c_.DataAccess1.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testwithapic_.Data;

namespace c_.DataAccess1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IArticlesRepository Articles { get; private set; }

        public IMyPropertyRepository MyProperty { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            Articles = new ArticalesRepository(_db);
            MyProperty = new MyPropertyRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
