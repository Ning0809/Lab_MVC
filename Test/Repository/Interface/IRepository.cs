using System.Collections.Generic;
using Lab_MVC.Service;

namespace Lab_MVC.Repository
{
    public interface IRepository
    {
        List<Product> Query();
        bool Create(Product product);
        bool Delete(int productId);
    }
}