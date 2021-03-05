using AutoMapper;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities.ResponseModels;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderServices.BL.Managers
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository _orderRepository;
        private IOrderItemRepository _orderItemRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public OrderManager(IOrderRepository orderRepository, IOrderItemRepository orderItemRepository, IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._orderItemRepository = orderItemRepository;
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task<List<OrderResponseModel>> GetAll()
        {
            List<Order> ordersEntity = await this._orderRepository.GetAll();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.GetAll();
            List<OrderItem> orderItemsEntity = await this._orderItemRepository.GetAll();
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach(OrderResponseModel order in orders)
            {
                order.OrderItems = orderDetailsEntity.Where(x => x.OrderId == order.Id).Select(x =>
                {
                    OrderItem orderItemEntity = orderItemsEntity.FirstOrDefault(y => y.Id == x.OrderItemId);
                    return this._mapper.Map<OrderItem, OrderItemResponseModel>(orderItemEntity);
                }).ToList();
            }
            return orders;
        } 
    }
}
