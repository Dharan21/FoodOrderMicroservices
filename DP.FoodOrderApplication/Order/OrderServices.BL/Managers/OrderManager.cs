using AutoMapper;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities.RequestModels;
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
        private IMenuItemRepository _menuItemRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;

        public OrderManager(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IOrderDetailRepository orderDetailRepository, IMapper mapper)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._menuItemRepository = menuItemRepository;
            this._orderRepository = orderRepository;
            this._mapper = mapper;
        }

        public async Task Add(OrderRequestModel order)
        {
            Order orderEntity = this._mapper.Map<OrderRequestModel, Order>(order);
            int orderId = await this._orderRepository.PlaceOrder(orderEntity);
            foreach(OrderItemRequestModel item in order.OrderedItems)
            {

            }
        }

        public async Task<List<OrderResponseModel>> GetAll()
        {
            List<Order> ordersEntity = await this._orderRepository.GetAll();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.GetAll();
            List<MenuItem> menuItemsEntity = await this._menuItemRepository.GetAll();
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach(OrderResponseModel order in orders)
            {
                order.OrderItems = orderDetailsEntity.Where(x => x.OrderId == order.Id).Select(x =>
                {
                    MenuItem MenuItemEntity = menuItemsEntity.FirstOrDefault(y => y.Id == x.OrderItemId);
                    return this._mapper.Map<MenuItem, OrderItemResponseModel>(MenuItemEntity);
                }).ToList();
            }
            return orders;
        } 
    }
}
