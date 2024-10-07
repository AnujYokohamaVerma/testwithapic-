using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testwithapic_.Models;

namespace c_.DataAccess1.Repository.IRepository
{
    public interface IArticlesRepository : IRepository<Articles>
    {
        void update(Articles obj);
        void Save();
    }
}
