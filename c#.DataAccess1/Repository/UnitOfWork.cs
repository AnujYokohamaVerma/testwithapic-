using Apollo.DataAccess1.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Apollo.DataAccess1.Data;

namespace Apollo.DataAccess1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }

        public IArticlesRepository Articles { get; private set; }

        public IMyPropertyRepository MyProperty { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        //public IProductImageRepository ProductImage { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
           // ProductImage = new ProductImageRepository(_db);
            Category = new CategoryRepository(_db);
            Articles = new ArticalesRepository(_db);
            MyProperty = new MyPropertyRepository(_db);
            ApplicationUser = new ApplicationUserRepository(_db);
        }
       

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
