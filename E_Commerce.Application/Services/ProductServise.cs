using AutoMapper;
using E_Commerce.Application.Common;
using E_Commerce.Application.Contracts;
using E_Commerce.Application.DTOs.Products;
using E_Commerce.Domain.Contracts;
using E_Commerce.Domain.Entities.Products;

namespace E_Commerce.Application.Services
{
    internal class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductService(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
      
        public async Task<Result<IReadOnlyList<BrandDto>>> GetAllBrandsAsync(CancellationToken ct)
        {
            var brands = await _unitOfWork.GetRepository<ProductBrand,int>().GetAllAsync(ct);
            var data = _mapper.Map<IReadOnlyList<BrandDto>>(brands);
            return Result<IReadOnlyList<BrandDto>>.OK(data);
        }

        public async Task<Result<IReadOnlyList<ProductDto>>> GetAllProductsAsync(CancellationToken ct)
        {
            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(ct);
            return Result<IReadOnlyList<ProductDto>>.OK(_mapper.Map<IReadOnlyList<ProductDto>>(products));
        }

        public async Task<Result<IReadOnlyList<TypeDto>>> GetAllTypesAsync(CancellationToken ct)
        {
            var types = _mapper.Map<IReadOnlyList<TypeDto>>(await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync(ct));
            return Result<IReadOnlyList<TypeDto>>.OK(types);
        }

        public async Task<Result<ProductDto>> GetProductByIdAsync(int id ,CancellationToken ct)
        {
           var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(id, ct);
           if(product == null)
                return Error.NotFound("ProductNotFound", $"Product with id {id} not found");
         
            return _mapper.Map<ProductDto>(product);
        }
    }
}
