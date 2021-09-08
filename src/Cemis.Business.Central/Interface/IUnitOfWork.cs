//  Copyright (c) 2011 Ray Liang (http://www.dotnetage.com)
//  http://www.gnu.org/licenses/gpl.html

using CEMIS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CEMIS.Business.Central.Interface
{
    public interface IUnitOfWork:IDisposable
    {
        int SaveChanges();
    }

    public interface IDbContext : IUnitOfWork
    {
        //ICategoryRepository Categories { get; }

        //IProductRepository Products { get; }
    }

    //public class Context : IDbContext
    //{
    //    private appContext dbContext;
    //    //private ICategoryRepository categories;
    //    //private IProductRepository products;

    //    //public Context()
    //    //{
    //    //    dbContext = new EnrouteContext();
    //    //}

    //    public Context(appContext dbcontext)
    //    {
    //        dbContext = dbcontext;
    //    }

    //    //public ICategoryRepository Categories
    //    //{
    //    //    get
    //    //    {
    //    //        if (categories == null)
    //    //            categories = new CategoryRepository(dbContext);
    //    //        return categories;
    //    //    }
    //    //}

    //    //public IProductRepository Products
    //    //{
    //    //    get 
    //    //    {
    //    //        if (products == null)
    //    //            products = new ProductRepostiroy(dbContext);
    //    //        return products;
    //    //    }
    //    //}

    //    public int SaveChanges()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    //public void Dispose()
    //    //{
    //    //    //if (categories != null)
    //    //    //    categories.Dispose();
    //    //    //if (products != null)
    //    //    //    products.Dispose();
    //    //    if (dbContext != null)
    //    //        dbContext.Dispose();
    //    //    GC.SuppressFinalize(this);
    //    //}
    //}
}
