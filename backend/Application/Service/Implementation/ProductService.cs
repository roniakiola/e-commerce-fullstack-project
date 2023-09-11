using Domain.Entity;
using Application.Dto;
using Domain.Abstraction.Repository;
using AutoMapper;
using Application.Service.Abstraction;

namespace Application.Service.Implementation
{
  public class ProductService : BaseService<Product, ProductReadDto, ProductCreateDto, ProductUpdateDto>, IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
    {
      _productRepository = productRepository;
    }
  }
}