using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private IProductRepository _produtctRepository;


        public ProductService(IMapper mapper, IProductRepository produtctRepository )
        {
            _produtctRepository = produtctRepository ??
                    throw new ArgumentException(nameof(produtctRepository));

            _mapper = mapper;
        }

        public async Task Add(ProductDTO productDto)
        {
            var produtcEntity = _mapper.Map<Product>(productDto);
            await _produtctRepository.CreateAsync(produtcEntity);
        }

        public async Task<ProductDTO> GetById(int? id)
        {
            var productEntity = await _produtctRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);
        }

        public async Task<ProductDTO> GetProductCategory(int? id)
        {
            var productEntity = await _produtctRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(productEntity);

            
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var productsEntity = await _produtctRepository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(productsEntity);
        }

        public async Task Remove(int? id)
        {
            var produtcEntity = _produtctRepository.GetByIdAsync(id).Result;
            await _produtctRepository.RemoveAsync(produtcEntity);
        }

        public async Task Update(ProductDTO productDTO)
        {
            var produtcEntity = _mapper.Map<Product>(productDTO);
            await _produtctRepository.UpdateAsync(produtcEntity);
        }

      
    }
}
