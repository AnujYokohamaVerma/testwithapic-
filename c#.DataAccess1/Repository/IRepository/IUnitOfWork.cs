using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apollo.DataAccess1.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get; }
        IArticlesRepository Articles { get; }
        IMyPropertyRepository MyProperty { get; }
        IApplicationUserRepository ApplicationUser { get; }
        //IProductImageRepository ProductImage { get; }

        void Save();

    }
}
