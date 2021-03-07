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
using static Infrastructure.Common.Enumerators.Enumerators;

namespace OrderServices.BL.Managers
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository _orderRepository;
        private IMenuItemRepository _menuItemRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IRestaurantRepository _restaurantRepository;
        private IDriverRepository _driverRepository;
        private IMapper _mapper;

        public OrderManager(IOrderRepository orderRepository, IMenuItemRepository menuItemRepository, IOrderDetailRepository orderDetailRepository, IRestaurantRepository restaurantRepository, IDriverRepository driverRepository, IMapper mapper)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._menuItemRepository = menuItemRepository;
            this._orderRepository = orderRepository;
            this._restaurantRepository = restaurantRepository;
            this._driverRepository = driverRepository;
            this._mapper = mapper;
        }

        public async Task Add(OrderRequestModel order)
        {
            Order orderEntity = this._mapper.Map<OrderRequestModel, Order>(order);
            int totalQuantity = 0;
            int totalPrice = 0;
            List<int> orderedItemsId = order.OrderedItems.Select(x => x.Id).ToList();
            List<MenuItem> items = await this._menuItemRepository.FindAllAsync(x => orderedItemsId.Contains(x.MenuItemId));
            order.OrderedItems.ForEach(x =>
            {
                totalQuantity += x.Quantity;
                totalPrice += items.First(y => y.MenuItemId == x.Id).Price * x.Quantity;
            });
            orderEntity.ItemsQuantity = totalQuantity;
            orderEntity.TotalPrice = totalPrice;
            int orderId = await this._orderRepository.PlaceOrder(orderEntity);
            foreach (OrderItemRequestModel item in order.OrderedItems)
            {
                OrderDetail orderDetailEntity = new OrderDetail()
                {
                    OrderId = orderId,
                    OrderedItemId = item.Id,
                    Quantity = item.Quantity
                };
                await this._orderDetailRepository.Create(orderDetailEntity);
            }
        }

        public async Task AssignDriver(AssignDriverRequestModel model)
        {
            Order orderEntity = await this._orderRepository.GetById(model.OrderId);
            orderEntity.DriverId = model.DriverId;
            orderEntity.Status = OrderStatus.DriverAssigned;
            await this._orderRepository.Update(orderEntity);
        }

        public async Task Delete(int orderId)
        {
            await this._orderRepository.Delete(orderId);
        }

        public async Task Edit(OrderRequestModel order)
        {
            List<OrderDetail> orderDetailsEntities = await this._orderDetailRepository.FindAllAsync(x => x.OrderId == order.Id);
            foreach(var details in orderDetailsEntities)
            {
                await this._orderDetailRepository.Delete(details.Id);
            }
            Order orderEntity = await this._orderRepository.GetById(order.Id);
            int totalQuantity = 0;
            int totalPrice = 0;
            List<int> orderedItemsId = order.OrderedItems.Select(x => x.Id).ToList();
            List<MenuItem> items = await this._menuItemRepository.FindAllAsync(x => orderedItemsId.Contains(x.MenuItemId));
            order.OrderedItems.ForEach(x =>
            {
                totalQuantity += x.Quantity;
                totalPrice += items.First(y => y.MenuItemId == x.Id).Price * x.Quantity;
            });
            orderEntity.ItemsQuantity = totalQuantity;
            orderEntity.TotalPrice = totalPrice;
            await this._orderRepository.Update(orderEntity);
            foreach (OrderItemRequestModel item in order.OrderedItems)
            {
                OrderDetail orderDetailEntity = new OrderDetail()
                {
                    OrderId = order.Id,
                    OrderedItemId = item.Id,
                    Quantity = item.Quantity
                };
                await this._orderDetailRepository.Create(orderDetailEntity);
            }
        }

        public async Task<List<OrderResponseModel>> GetAll()
        {
            List<Order> ordersEntity = await this._orderRepository.GetAll();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.GetAll();
            List<MenuItem> menuItemsEntity = await this._menuItemRepository.GetAll();
            List<int> restaurantsIds = ordersEntity.Select(x => x.RestaurantId).ToList();
            List<int> driversIds = ordersEntity.Select(x => x.DriverId ?? 0).Where(x => x != 0).ToList();
            List<Restaurant> restaurantsEntity = await this._restaurantRepository.FindAllAsync(x => restaurantsIds.Contains(x.RestaurantId));
            List<Driver> driversEntity = await this._driverRepository.FindAllAsync(x => driversIds.Contains(x.DriverId));
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                order.RestaurantName = restaurantsEntity.FirstOrDefault(x => x.RestaurantId == order.RestaurantId).Name;
                if (order.DriverId.HasValue)
                {
                    Driver driverEntity = driversEntity.FirstOrDefault(x => x.DriverId == order.DriverId);
                    if (driverEntity != null)
                        order.DriverName = $"${driverEntity.FirstName} ${driverEntity.LastName}";
                }
                order.OrderItems = orderDetailsEntity.Where(x => x.OrderId == order.Id).Select(x =>
                {
                    MenuItem menuItemEntity = menuItemsEntity.FirstOrDefault(y => y.Id == x.OrderedItemId);
                    OrderItemResponseModel orderedItem = new OrderItemResponseModel()
                    {
                        MenuItemName = menuItemEntity.Name,
                        Price = menuItemEntity.Price,
                        Quantity = x.Quantity
                    };
                    return orderedItem;
                }).ToList();
            }
            return orders;
        }
    }
}
