using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;
using WebAPI.Models;

namespace WebAPI.DataAccess
{
    public interface IProductDal : IEntityRepository<Product>
    {
        List<ProductModel> GetProductsWithDetails(); 
    }
}
