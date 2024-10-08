using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using c_.DataAccess1.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using testwithapic_.Data;
using testwithapic_.Models;

namespace c_.DataAccess1.Repository
{
    public class ArticalesRepository : Repository<Articles>, IArticlesRepository
    {
        private ApplicationDbContext _db;
        public ArticalesRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void update(Articles obj)
        {
            _db.Articles.Update(obj);
        }

        public void Detach(Articles entity)
        {
            _db.Entry(entity).State = EntityState.Detached;
        }

    }
}
