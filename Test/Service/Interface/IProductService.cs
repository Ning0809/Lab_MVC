using System.Collections.Generic;
using Lab_MVC.Models;

namespace Lab_MVC.Service
{
    public interface IProductService
    {
        List<ProductDto> GetProductList();
        ProductDto GetProduct(int id);
        bool CreateProduct(ProductDto productDto);
    }
}