﻿using AutoMapper;
using Grpc.Net.Client;
using Infrastructure.Common.Constants;
using Infrastructure.Common.Utility;
using Microsoft.Extensions.Configuration;
using OrderServices.BL.Interfaces;
using OrderServices.BusinessEntities;
using OrderServices.BusinessEntities.RequestModels;
using OrderServices.BusinessEntities.ResponseModels;
using OrderServices.DataEntities.Entities;
using OrderServices.DL.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Infrastructure.Common.Enumerators.Enumerators;

namespace OrderServices.BL.Managers
{
    public class OrderManager : IOrderManager
    {
        private IOrderRepository _orderRepository;
        private IOrderDetailRepository _orderDetailRepository;
        private IMapper _mapper;
        private IConfiguration _configuration;

        public OrderManager(IOrderRepository orderRepository, IOrderDetailRepository orderDetailRepository, IMapper mapper, IConfiguration configuration)
        {
            this._orderDetailRepository = orderDetailRepository;
            this._orderRepository = orderRepository;
            this._mapper = mapper;
            this._configuration = configuration;
        }

        public async Task Add(OrderRequestModel order)
        {
            string menuIdsString = string.Join(',', order.OrderedItems.Select(x => x.Id.ToString()));
            var getCustomerAPI = GetCustomer(order.CustomerId);
            var getRestaurantAPI = GetRestaurant(order.RestaurantId);
            var getMenuItems = GetMenuItems(menuIdsString);
            
            Order orderEntity = this._mapper.Map<OrderRequestModel, Order>(order);
            
            Customer customer = await getCustomerAPI;
            orderEntity.CustomerName = $"{customer.FirstName} {customer.LastName}";

            Restaurant restaurant = await getRestaurantAPI;
            orderEntity.RestaurantName = restaurant.Name;

            List<MenuItem> menuItems = await getMenuItems;
            int totalQuantity = 0;
            int totalPrice = 0;
            order.OrderedItems.ForEach(x =>
            {
                totalQuantity += x.Quantity;
                totalPrice += (menuItems.First(menuItem => menuItem.Id == x.Id).Price * x.Quantity);
            });
            orderEntity.ItemsQuantity = totalQuantity;
            orderEntity.TotalPrice = totalPrice;
            
            int orderId = await this._orderRepository.PlaceOrder(orderEntity);

            foreach (OrderItemRequestModel item in order.OrderedItems)
            {
                MenuItem menuItem = menuItems.FirstOrDefault(x => x.Id == item.Id);
                OrderDetail orderDetailEntity = new OrderDetail()
                {
                    OrderId = orderId,
                    OrderedItemId = item.Id,
                    OrderedItemName = menuItem != null ? menuItem.Name : string.Empty,
                    Quantity = item.Quantity,
                    Price = menuItem != null ? menuItem.Price : 0
                };
                await this._orderDetailRepository.Create(orderDetailEntity);
            }
        }

        public async Task AssignDriver(AssignDriverRequestModel model)
        {
            Order orderEntity = await this._orderRepository.GetById(model.OrderId);
            Driver driver = await GetDriver(model.DriverId);
            orderEntity.DriverId = model.DriverId;
            orderEntity.DriverName = $"{driver.FirstName} {driver.LastName}";
            orderEntity.Status = OrderStatus.DriverAssigned;
            await this._orderRepository.Update(orderEntity);
        }

        public async Task Delete(int orderId)
        {
            await this._orderRepository.Delete(orderId);
        }

        public async Task Edit(OrderRequestModel order)
        {
            string menuIdsString = string.Join(',', order.OrderedItems.Select(x => x.Id.ToString()));
            List<MenuItem> menuItems = await GetMenuItems(menuIdsString);
            Order orderEntity = await this._orderRepository.GetById(order.Id);

            int totalQuantity = 0;
            int totalPrice = 0;
            order.OrderedItems.ForEach(x =>
            {
                totalQuantity += x.Quantity;
                totalPrice += menuItems.First(menuItem => menuItem.Id == x.Id).Price;
            });
            orderEntity.ItemsQuantity = totalQuantity;
            orderEntity.TotalPrice = totalPrice;

            await this._orderRepository.Update(orderEntity);

            List<OrderDetail> orderedItemEntities = await this._orderDetailRepository.FindAllAsync(x => x.OrderId == orderEntity.Id);
            foreach(OrderDetail orderedItemEntity in orderedItemEntities)
            {
                await this._orderDetailRepository.Delete(orderedItemEntity.Id);
            }

            foreach (OrderItemRequestModel item in order.OrderedItems)
            {
                OrderDetail orderDetailEntity = new OrderDetail()
                {
                    OrderId = order.Id,
                    OrderedItemId = item.Id,
                    OrderedItemName = menuItems.FirstOrDefault(x => x.Id == item.Id)?.Name,
                    Quantity = item.Quantity
                };
                await this._orderDetailRepository.Create(orderDetailEntity);
            }
        }

        public async Task<MonthlyReportResponseModel> GenerateMonthlyReport(int restaurantId, int month)
        {
            MonthlyReportResponseModel responseObject = new MonthlyReportResponseModel();
            if (month == -1)
                month = DateTime.UtcNow.Month;
            responseObject.Month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(month);
            responseObject.RestaurantId = restaurantId;

            var getRestaurantAPI = GetRestaurant(restaurantId);

            List<Order> ordersEntity = await this._orderRepository.FindAllAsync(x => x.RestaurantId == restaurantId && x.DateTime.Month == month && x.Status == OrderStatus.Delivered);
            List<int> orderIds = ordersEntity.Select(x => x.Id).ToList();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.FindAllAsync(x => orderIds.Contains(x.OrderId));
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                var orderDetails = orderDetailsEntity.Where(x => x.OrderId == order.Id).ToList();
                order.OrderItems = this._mapper.Map<List<OrderDetail>, List<OrderItemResponseModel>>(orderDetails);
            }
            responseObject.DeliveredOrders = orders;

            Restaurant restaurant = await getRestaurantAPI;
            responseObject.RestaurantName = restaurant.Name;

            return responseObject;
        }

        public async Task<List<OrderResponseModel>> GetAll()
        {
            List<Order> ordersEntity = await this._orderRepository.GetAll();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.GetAll();
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                var orderDetails = orderDetailsEntity.Where(x => x.OrderId == order.Id).ToList();
                order.OrderItems = this._mapper.Map<List<OrderDetail>, List<OrderItemResponseModel>>(orderDetails); 
            }
            return orders;
        }

        public async Task<List<OrderResponseModel>> GetByCustomer(int customerId)
        {
            List<Order> ordersEntity = await this._orderRepository.FindAllAsync(x => x.CustomerId == customerId);
            List<int> orderIds = ordersEntity.Select(x => x.Id).ToList();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.FindAllAsync(x => orderIds.Contains(x.OrderId));
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                var orderDetails = orderDetailsEntity.Where(x => x.OrderId == order.Id).ToList();
                order.OrderItems = this._mapper.Map<List<OrderDetail>, List<OrderItemResponseModel>>(orderDetails);
            }
            return orders;
        }

        public async Task<List<OrderResponseModel>> GetByDriver(int driverId)
        {
            List<Order> ordersEntity = await this._orderRepository.FindAllAsync(x => x.DriverId == driverId);
            List<int> orderIds = ordersEntity.Select(x => x.Id).ToList();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.FindAllAsync(x => orderIds.Contains(x.OrderId));
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                var orderDetails = orderDetailsEntity.Where(x => x.OrderId == order.Id).ToList();
                order.OrderItems = this._mapper.Map<List<OrderDetail>, List<OrderItemResponseModel>>(orderDetails);
            }
            return orders;
        }

        public async Task<List<OrderResponseModel>> GetByRestaurant(int restaurantId)
        {
            List<Order> ordersEntity = await this._orderRepository.FindAllAsync(x => x.RestaurantId == restaurantId);
            List<int> orderIds = ordersEntity.Select(x => x.Id).ToList();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.FindAllAsync(x => orderIds.Contains(x.OrderId));
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                var orderDetails = orderDetailsEntity.Where(x => x.OrderId == order.Id).ToList();
                order.OrderItems = this._mapper.Map<List<OrderDetail>, List<OrderItemResponseModel>>(orderDetails);
            }
            return orders;
        }

        public async Task<List<OrderResponseModel>> GetByRestaurant(int restaurantId, int driverId)
        {
            List<Order> ordersEntity = await this._orderRepository.FindAllAsync(x => x.RestaurantId == restaurantId && x.DriverId == driverId);
            List<int> orderIds = ordersEntity.Select(x => x.Id).ToList();
            List<OrderDetail> orderDetailsEntity = await this._orderDetailRepository.FindAllAsync(x => orderIds.Contains(x.OrderId));
            List<OrderResponseModel> orders = this._mapper.Map<List<Order>, List<OrderResponseModel>>(ordersEntity);
            foreach (OrderResponseModel order in orders)
            {
                var orderDetails = orderDetailsEntity.Where(x => x.OrderId == order.Id).ToList();
                order.OrderItems = this._mapper.Map<List<OrderDetail>, List<OrderItemResponseModel>>(orderDetails);
            }
            return orders;
        }

        private async Task<Customer> GetCustomer(int customerId)
        {
            //string getCustomerUri = $"{this._configuration[Constants.GatewayEndPointKey]}/{Constants.CustomerServicesPrefix}/{Constants.CustomerServiceCustomersController}/{Constants.Get}/{customerId}";
            //return await HttpRequestClient.GetRequest<Customer>(getCustomerUri);

            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new CustomerGrpcService.Protos.CustomerGrpcProtoService.CustomerGrpcProtoServiceClient(channel);

            var customer = await client.GetCustomerAsync(new CustomerGrpcService.Protos.GetCustomerRequest() { CustomerId = customerId });

            return _mapper.Map<Customer>(customer);
        }

        private async Task<Restaurant> GetRestaurant(int restautantId)
        {
            //string getRestaurantUri = $"{this._configuration[Constants.GatewayEndPointKey]}/{Constants.RestaurantServicesPrefix}/{Constants.RestaurantServiceRestaurantController}/{Constants.Get}/{restautantId}";
            //return await HttpRequestClient.GetRequest<Restaurant>(getRestaurantUri);

            var channel = GrpcChannel.ForAddress("https://localhost:6001");
            var client = new RestaurantGrpcService.Protos.RestaurantProtoService.RestaurantProtoServiceClient(channel);

            var response = await client.GetRestaurantAsync(new RestaurantGrpcService.Protos.GetRestaurantRequestModel { RestaurantId = restautantId });
            return this._mapper.Map<RestaurantGrpcService.Protos.GetRestaurantResposneModel, Restaurant>(response);
        }

        private async Task<Driver> GetDriver(int driverId)
        {
            string getDriverUri = $"{this._configuration[Constants.GatewayEndPointKey]}/{Constants.DriverServicesPrefix}/{Constants.DriverServiceDriversController}/{Constants.Get}/{driverId}";
            return await HttpRequestClient.GetRequest<Driver>(getDriverUri);
        }

        private async Task<List<MenuItem>> GetMenuItems(string menuItemIds)
        {
            //string getMenuItemsUri = $"{this._configuration[Constants.GatewayEndPointKey]}/{Constants.RestaurantServicesPrefix}/{Constants.RestaurantServiceMenuItemController}/{Constants.GetAll}/{menuItemIds}";
            //return await HttpRequestClient.GetRequest<List<MenuItem>>(getMenuItemsUri);

            var channel = GrpcChannel.ForAddress("https://localhost:6001");
            var client = new RestaurantGrpcService.Protos.MenuItemProtoService.MenuItemProtoServiceClient(channel);

            var response = await client.GetMenuListAsync(new RestaurantGrpcService.Protos.GetMenuListRequest { Ids = menuItemIds });
            return this._mapper.Map<List<RestaurantGrpcService.Protos.MenuItem>, List<MenuItem>>(response.MenuItems.ToList());
        }
    }
}
