using Domain.Entity;
using Application.Dto;
using Domain.Abstraction.Repository;
using AutoMapper;
using Application.Service.Abstraction;
using Domain.Shared;

namespace Application.Service.Implementation
{
  public class ProductService : BaseService<Product, ProductCreateDto, ProductReadDto, ProductUpdateDto>, IProductService
  {
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository, IMapper mapper) : base(productRepository, mapper)
    {
      _productRepository = productRepository;
    }

    public async Task<List<ProductReadDto>> GetByQueryAsync(QueryOptions queryOptions)
    {
      var products = await _productRepository.GetByQueryAsync(queryOptions);

      return _mapper.Map<List<ProductReadDto>>(products);
    }
  }
}