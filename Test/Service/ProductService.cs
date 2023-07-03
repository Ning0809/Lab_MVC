using System.Collections.Generic;
using System.Linq;
using Lab_MVC.Models;
using Lab_MVC.Repository;

namespace Lab_MVC.Service
{
    public class ProductService : IProductService
    {
        private readonly IRepository _repository;

        public ProductService(IRepository repository)
        {
            _repository = repository;
        }

        public List<ProductDto> GetProductList()
        {
            var productDtos = _repository.Query().Select(product=> new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                ImgUrl = product.ImgUrl,
                Price = product.Price
            }).ToList();
            return productDtos;
        }

        public ProductDto GetProduct(int id)
        {
            var productDto =  _repository.Query()
                .Where(product => product.Id == id)
                .Select(product=>new ProductDto
                {
                    Id = product.Id,
                    Name = product.Name,
                    ImgUrl = product.ImgUrl,
                    Price = product.Price
                })
                .Single();
            return productDto;
        }

        public bool CreateProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Id = productDto.Id,
                Name = productDto.Name,
                ImgUrl = productDto.ImgUrl,
                Price = productDto.Price
            };
            return _repository.Create(product);
        }
    }
}
