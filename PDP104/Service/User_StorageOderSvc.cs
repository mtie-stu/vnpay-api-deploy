using PDP104.Data;
using PDP104.ViewModel;
using PDP104.Models;

using System.Collections.Generic;
using System.Linq;
using PDP104.Models.ViewModel;

namespace PDP104.Service
{
    public interface IUserStorageOrder
    {
        List<Models.ViewModel.UserStorageViewModel> GetAllStorageOrderByUser(string nguoiDungId);
        Models.ViewModel.UserStorageViewModel GetStorageOrder(int id);
        int AddStorageOrder(Models.ViewModel.UserStorageViewModel userStorageViewModel, StatusInventory statusInventory);
/*        int EditService(int id, Models.ViewModel.UserStorageViewModel userStorageViewModel);
*/    }

    public class UserStorageOrderSvc : IUserStorageOrder
    {
        protected ApplicationDbContext _context;
        public UserStorageOrderSvc(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Models.ViewModel.UserStorageViewModel> GetAllStorageOrderByUser(string nguoiDungId)
        {
            return _context.StorageOrders
                .Where(s => s.NguoiDungId == nguoiDungId) // Lọc theo NguoiDungId
                .Select(s => new Models.ViewModel.UserStorageViewModel
                {
                    Id = s.Id,
                    OrderDate = s.OrderDate,
                    DateOfEntry = s.DateOfEntry,
                    DateOfShipment = s.DateOfShipment,
                    SatusOrder = s.StatusOrder,
                    TypeOfGoods=s.TypeOfGoods,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    Hinh = s.Hinh,
                })
                .ToList();
        }


        public Models.ViewModel.UserStorageViewModel GetStorageOrder(int id)
        {
            return _context.StorageOrders
                .Where(s => s.Id == id)
                .Select(s => new Models.ViewModel.UserStorageViewModel
                {
                    Id = s.Id,
                    OrderDate = s.OrderDate,
                    DateOfEntry = s.DateOfEntry,
                    DateOfShipment = s.DateOfShipment,
                    SatusOrder = s.StatusOrder,
                    TypeOfGoods = s.TypeOfGoods,
                    Price = s.Price,
                    Quantity = s.Quantity,
                    Hinh = s.Hinh,
                    

                })
                .FirstOrDefault();
        }


        public int AddStorageOrder(Models.ViewModel.UserStorageViewModel userStorageViewModel, StatusInventory statusInventory)
        {
            var newOrder = new StorageOrders
            {
                OrderDate = userStorageViewModel.OrderDate,
                DateOfEntry = userStorageViewModel.DateOfEntry,
                DateOfShipment = userStorageViewModel.DateOfShipment,
                TypeOfGoods=userStorageViewModel.TypeOfGoods,
                StatusOrder = StatusOrder.Confirming, // Đặt trạng thái mặc định là Confirming
                StatusInventory = userStorageViewModel.StatusInventory, 
/*                Price = userStorageViewModel.Price,
*/                Quantity = userStorageViewModel.Quantity,
                Hinh = userStorageViewModel.Hinh,
                NguoiDungId = userStorageViewModel.NguoiDungId // Đảm bảo có ID người dùng

            };

            _context.StorageOrders.Add(newOrder);
            _context.SaveChanges();

          

            return newOrder.Id;
        }





   /*     public int EditOrder(int id, Models.ViewModel.UserStorageViewModel userStorageViewModel)
        {
            var order = _context.StorageOrders.Find(id);
            if (order == null)
            {
                return 0; // Trả về 0 nếu không tìm thấy đơn hàng
            }

            order.DateOfEntry = userStorageViewModel.DateOfEntry;

            order.DateOfShipment = userStorageViewModel.DateOfShipment;


            _context.StorageOrders.Update(order);
            _context.SaveChanges();

            return order.Id;
        }*/

    }
}

