using AutoMapper;
using BusinessLogic.DTOs;
using BusinessLogic.Interfaces;
using DataAccess.Data;
using DataAccess.Data.Entities;
using DataAccess.Repositories;


namespace BusinessLogic.Services
{
    internal class OrdersService : IOrdersService
    {
        private readonly IMapper mapper;
        private readonly IReposiroty<Order> orderR;
        private readonly IReposiroty<Product> productR;

        // private readonly ShopDbContext context;
        private readonly IBasketService basketService;

        public OrdersService(IMapper mapper, IReposiroty<Order> orderR, IReposiroty<Product> productR, IBasketService basketService) 
        {
            this.mapper = mapper;
            this.orderR = orderR;
            this.productR = productR;
            this.basketService = basketService;
        }
        public void Create(string userId)
        {
            var ids = basketService.GetProductsIds();
            var products = productR.Get(x => ids.Contains(x.Id)).ToList();
            var order = new Order()
            {
                Date = DateTime.Now,
                UserId = userId,
                Products = products,
                TotalPrice = products.Sum(x => x.Price),
            };

            orderR.Insert(order);
            orderR.Save();             
        }

        public Task<IEnumerable<OrderDto>> GetAllByUser(string userId)
        {
            var items = orderR.Get(x => x.UserId == userId, includeProperties: "Products"); 
            return (Task<IEnumerable<OrderDto>>)mapper.Map<IEnumerable<OrderDto>>(items);
        }

        Task IOrdersService.Create(string userId)
        {
            throw new NotImplementedException();
        }

    }
}

