using Microsoft.EntityFrameworkCore;
using PDP104.Data;
using PDP104.Models;
using PDP104.Models.ViewModel;
using PDP104.ViewModel;

namespace PDP104.Service
{
    public interface IAdminStorageOrderSvc
    {
        List<Models.ViewModel.AdminStorageViewModel> GetAllStorageOrder();
        List<AdminStorageViewModel> GetAllStorageOrderWhereInventoryActive();
        Models.ViewModel.AdminStorageViewModel GetStorageOrder(int id);
        int SetLocationStorageOrder(Models.ViewModel.AdminStorageViewModel adminStorageViewModel, StatusInventory statusInventory);
        int EditOrder(int id, Models.ViewModel.AdminStorageViewModel adminStorageViewModel);
        int ImportingOder(int id, Models.ViewModel.AdminStorageViewModel adminStorageViewModel);
        int ExportingOrder(int id, Models.ViewModel.AdminStorageViewModel adminStorageViewModel);


    }
    public class Admin_StorageOrderSvc
    {
        private readonly ApplicationDbContext _context;

        public Admin_StorageOrderSvc(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<AdminStorageViewModel> GetAllStorageOrder()
        {
            return _context.StorageOrders
                .Select(order => new AdminStorageViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    DateOfEntry = order.DateOfEntry,
                    DateOfShipment = order.DateOfShipment,
                    StatusOrder = order.StatusOrder,
                    StatusInventory = order.StatusInventory,
                    TypeOfGoods = order.TypeOfGoods,
                    Price = order.Price,
                    Quantity = order.Quantity,
                    Hinh = order.Hinh,
                    NguoiDungId = order.NguoiDungId,
                    ServiceId = order.InventoryId ?? 0,
                    Floor = order.StorageSpaces != null ? order.StorageSpaces.Count() : 0,
                    LocationStorage = order.StorageSpaces != null ? string.Join(", ", order.StorageSpaces.Select(s => s.LocationStorage)) : ""
                })
                .ToList();
        }

        public AdminStorageViewModel GetStorageOrder(int id)
        {
            return _context.StorageOrders
                .Where(order => order.Id == id)
                .Select(order => new AdminStorageViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    DateOfEntry = order.DateOfEntry,
                    DateOfShipment = order.DateOfShipment,
                    StatusOrder = order.StatusOrder,
                    StatusInventory = order.StatusInventory,
                    TypeOfGoods = order.TypeOfGoods,
                    Price = order.Price,
                    Quantity = order.Quantity,
                    Hinh = order.Hinh,
                    NguoiDungId = order.NguoiDungId,
                    ServiceId = order.InventoryId ?? 0,
                    Floor = order.StorageSpaces != null ? order.StorageSpaces.Count() : 0,
                    LocationStorage = order.StorageSpaces != null ? string.Join(", ", order.StorageSpaces.Select(s => s.LocationStorage)) : ""
                })
                .FirstOrDefault();
        }

        public int SetLocationStorageOrder(int orderId, AdminStorageViewModel adminStorageViewModel, StatusInventory statusInventory)
        {
            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return 0; // Nếu đơn hàng không tồn tại

            // Tính tổng số ngày lưu trữ
            int totalDays = (order.DateOfShipment - order.DateOfEntry).Days;

            // Xác định kho hàng dựa trên loại hàng hóa
            int warehouseId = order.TypeOfGoods == TypeOfGoods.Balet ? 2 : 1;

            // Lấy danh sách các vị trí còn trống theo loại hàng hóa
            var availableSpaces = _context.StorageSpaces
                .Where(s => s.StorageOrdersId == null && s.WareHouseId == warehouseId)
                .OrderBy(s => s.Floor)
                .Take(adminStorageViewModel.Quantity)
                .ToList();

            if (availableSpaces.Count < adminStorageViewModel.Quantity)
            {
                return -1; // Không đủ vị trí lưu trữ
            }

            foreach (var space in availableSpaces)
            {
                space.StorageOrdersId = order.Id;
                space.LocationStorage = adminStorageViewModel.LocationStorage;
                space.Floor = adminStorageViewModel.Floor;
                space.Status = StatusStorage.full;
            }

            var servicesList = new List<int>();
            decimal totalPrice = 0;

            if (totalDays <= 30)
            {
                int serviceId = GetServiceId(order.TypeOfGoods, "day");
                servicesList.Add(serviceId);
                totalPrice += GetServicePrice(serviceId) * order.Quantity;
            }
            else if (totalDays == 365)
            {
                int serviceId = GetServiceId(order.TypeOfGoods, "year");
                servicesList.Add(serviceId);
                totalPrice += GetServicePrice(serviceId) * order.Quantity;
            }
            else
            {
                int months = totalDays / 30;
                int days = totalDays % 30;

                for (int i = 0; i < months; i++)
                {
                    int serviceId = GetServiceId(order.TypeOfGoods, "month");
                    servicesList.Add(serviceId);
                    totalPrice += GetServicePrice(serviceId) * order.Quantity;
                }
                if (days > 0)
                {
                    int serviceId = GetServiceId(order.TypeOfGoods, "day");
                    servicesList.Add(serviceId);
                    totalPrice += GetServicePrice(serviceId) * order.Quantity;
                }
            }
            // Nếu StatusInventory là Active, tạo một bản ghi Inventory mới
            if (statusInventory == StatusInventory.Active)
            {
                var newInventory = new Inventory
                {
                    RequestDate = DateTime.Now,
                    StorageOrdersId = order.Id
                };
                _context.Inventories.Add(newInventory);
                _context.SaveChanges();
            }
            if (order.StatusInventory == StatusInventory.Active)
            {
                int serviceId = GetInventoryServiceId(order.TypeOfGoods);
                servicesList.Add(serviceId);
                totalPrice += GetServicePrice(serviceId) * order.Quantity;
            }

            var serviceOrders = servicesList.Select(serviceId => new StorageOrderServices
            {
                StorageOrderId = order.Id,
                ServiceId = serviceId
            }).ToList();

            _context.StorageOrderServices.AddRange(serviceOrders);

            order.StatusOrder = StatusOrder.Confirmed;
            order.Price = totalPrice;

            _context.UpdateRange(availableSpaces);
            _context.Update(order);
            _context.SaveChanges();

            return 1;
        }


        private int GetServiceId(TypeOfGoods typeOfGoods, string duration)
        {
            return typeOfGoods switch
            {
                TypeOfGoods.Balet => duration == "day" ? 1 : duration == "month" ? 2 : 3,
                TypeOfGoods.Container18ft => duration == "day" ? 4 : duration == "month" ? 5 : 6,
                TypeOfGoods.Container20ft => duration == "day" ? 7 : duration == "month" ? 8 : 9,
                TypeOfGoods.Container22ft => duration == "day" ? 10 : duration == "month" ? 11 : 12,
                _ => 0
            };
        }

        private int GetInventoryServiceId(TypeOfGoods typeOfGoods)
        {
            return typeOfGoods switch
            {
                TypeOfGoods.Container18ft => 13,
                TypeOfGoods.Container20ft => 14,
                TypeOfGoods.Container22ft => 15,
                _ => 0
            };
        }

        private decimal GetServicePrice(int serviceId)
        {
            return _context.Services.FirstOrDefault(s => s.Id == serviceId)?.UnitPrice ?? 0;
        }



        public int EditOrder(int id, AdminStorageViewModel adminStorageViewModel)
        {
            var today = DateTime.Now;
            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == id);

            if (order != null)
            {
                // Kiểm tra nếu DateOfEntry đã qua ngày hiện tại
                if (order.DateOfEntry < today)
                {
                    return 0; // Không thể chỉnh sửa vì ngày nhập đã qua
                }

                // Kiểm tra nếu DateOfShipment nhỏ hơn DateOfEntry hoặc nhỏ hơn ngày hiện tại
                if (adminStorageViewModel.DateOfShipment < adminStorageViewModel.DateOfEntry ||
                    adminStorageViewModel.DateOfShipment < today)
                {
                    return 0; // Không thể chỉnh sửa vì ngày xuất không hợp lệ
                }

                order.DateOfEntry = adminStorageViewModel.DateOfEntry;
                order.DateOfShipment = adminStorageViewModel.DateOfShipment;

                _context.Update(order);
                _context.SaveChanges();
                return 1;
            }

            return 0;
        }


        public int ImportingOrder(int id)
        {
            var today = DateTime.Now;

            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == id);
            if (order == null) return 0; // Nếu đơn hàng không tồn tại
            if (order.DateOfEntry < today || order.DateOfEntry > today)
            {
                // Cập nhật ngày nhập hàng và trạng thái đơn hàng
                order.StatusOrder = StatusOrder.Imported;

                // Lấy danh sách các vị trí lưu trữ của đơn hàng
                var storageSpaces = _context.StorageSpaces.Where(s => s.StorageOrdersId == id).ToList();

                // Cập nhật trạng thái của các vị trí lưu trữ thành Full
                foreach (var space in storageSpaces)
                {
                    space.Status = StatusStorage.full; // Đánh dấu vị trí đã được sử dụng
                }

                // Lưu thay đổi vào database
                _context.UpdateRange(storageSpaces);
                _context.Update(order);
                _context.SaveChanges();

                return 1; // Thành công
            }
            return 0;
        }


        public int ExportingOrder(int id, DateTime dateOfShipment)
        {
            var today = DateTime.Now;

            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == id);
            if (order == null) return 0; // Nếu đơn hàng không tồn tại
            if (dateOfShipment.Date == today.Date)
            {
                // Cập nhật ngày xuất hàng và trạng thái đơn hàng
                order.DateOfShipment = dateOfShipment;
                order.StatusOrder = StatusOrder.Exported;

                // Lấy danh sách các vị trí lưu trữ của đơn hàng
                var storageSpaces = _context.StorageSpaces.Where(s => s.StorageOrdersId == id).ToList();

                // Cập nhật trạng thái của các vị trí lưu trữ thành Empty
                foreach (var space in storageSpaces)
                {
                    space.Status = StatusStorage.empty; // Đánh dấu vị trí đã trống
                    space.StorageOrdersId = null; // Xóa liên kết với đơn hàng
                }

                // Lưu thay đổi vào database
                _context.UpdateRange(storageSpaces);
                _context.Update(order);
                _context.SaveChanges();

                return 1; // Thành công
            }
            return 0;
        }
        public List<AdminStorageViewModel> GetAllStorageOrderWhereInventoryActive()
        {
            return _context.StorageOrders
                .Where(order => order.StatusInventory == StatusInventory.Active) // Chỉ lấy đơn hàng có StatusInventory là Active
                .Select(order => new AdminStorageViewModel
                {
                    Id = order.Id,
                    OrderDate = order.OrderDate,
                    DateOfEntry = order.DateOfEntry,
                    DateOfShipment = order.DateOfShipment,
                    StatusOrder = order.StatusOrder,
                    StatusInventory = order.StatusInventory,
                    TypeOfGoods = order.TypeOfGoods,
                    Price = order.Price,
                    Quantity = order.Quantity,
                    Hinh = order.Hinh,
                    NguoiDungId = order.NguoiDungId,
                    ServiceId = order.InventoryId ?? 0,
                    Floor = order.StorageSpaces != null ? order.StorageSpaces.Count() : 0,
                    LocationStorage = order.StorageSpaces != null ? string.Join(", ", order.StorageSpaces.Select(s => s.LocationStorage)) : ""
                })
                .ToList();
        }
    }

    

}

