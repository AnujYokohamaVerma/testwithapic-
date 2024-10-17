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
    public class MyPropertyRepository : Repository<MyProperty>, IMyPropertyRepository
    {
        private ApplicationDbContext _db;
        public MyPropertyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Save()
        {
            _db.SaveChanges();
        }

        public void update(MyProperty obj)
        {
            _db.MyProperty.Update(obj);
        }
    }
}
