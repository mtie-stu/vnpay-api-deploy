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
                OrderDate = DateTime.SpecifyKind(userStorageViewModel.OrderDate, DateTimeKind.Utc),
                DateOfEntry = DateTime.SpecifyKind(userStorageViewModel.DateOfEntry, DateTimeKind.Utc),
                DateOfShipment = DateTime.SpecifyKind(userStorageViewModel.DateOfShipment, DateTimeKind.Utc),
                TypeOfGoods = userStorageViewModel.TypeOfGoods,
                StatusOrder = StatusOrder.Confirming,
                StatusInventory = userStorageViewModel.StatusInventory,
                Quantity = userStorageViewModel.Quantity,
                Hinh = userStorageViewModel.Hinh,
                NguoiDungId = userStorageViewModel.NguoiDungId
            };


            _context.StorageOrders.Add(newOrder);
            _context.SaveChanges();

          

            return newOrder.Id;
        }





  

    }
}

