using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testwithapic_.Data;
using testwithapic_.Models;

namespace c_.DataAccess1.Repository.IRepository
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
