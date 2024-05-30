using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Shop_Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IMapper mapper;
        private readonly IReposiroty<Product> productsR;
        private readonly IReposiroty<Category> categoriesR;

        public ProductsService(IMapper mapper,
                                IReposiroty<Product> productsR,
                                IReposiroty<Category> categoriesR)
        {
            this.mapper = mapper;
            this.productsR = productsR;
            this.categoriesR = categoriesR;
        }

        public void Create(CreateProductModel product)
        {
            productsR.Insert(mapper.Map<Product>(product));
            productsR.Save();
        }

        public void Delete(int id)
        {
            if (id < 0) throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);

            var product = productsR.GetByID(id);

            if (product == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            productsR.Delete(product);
            productsR.Save();

        }

        public void Edit(ProductDto product)
        {
            productsR.Update(mapper.Map<Product>(product));
            productsR.Save();
        }

        public ProductDto? Get(int id)
        {
            if (id < 0) throw new HttpException("Id can not be negative.", HttpStatusCode.BadRequest);
            var item = (productsR.GetByID(id));
            if (item == null) throw new HttpException("Product not found.", HttpStatusCode.NotFound);

            // context.Entry(item).Reference(x => x.Category).Load();

            var dto = mapper.Map<ProductDto>(item);

            return dto;
        }

        public IEnumerable<ProductDto> Get(IEnumerable<int> ids)
        {
            return mapper.Map<List<ProductDto>>(productsR.Get(x => ids.Contains(x.Id), includeProperties: "Category"));
        }

        public IEnumerable<ProductDto> GetAll()
        {
            return mapper.Map<List<ProductDto>>(productsR.GetAll());
        }

        public IEnumerable<CategoryDto> GetAllCategories()
        {
            return mapper.Map<List<CategoryDto>>(categoriesR.GetAll());
        }
    }
}

