using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApolloWeb.Models;

namespace Apollo.DataAccess1.Repository.IRepository
{
    public interface IArticlesRepository : IRepository<Articles>
    {
        void update(Articles obj);
        void Save();
        public void Detach(Articles entity);
    }
}
