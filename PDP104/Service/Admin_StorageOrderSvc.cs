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

        public int SetLocationStorageOrder(int orderId, AdminStorageViewModel adminStorageViewModel)
        {
            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == orderId);
            if (order == null) return 0; // Nếu đơn hàng không tồn tại

            // Lấy danh sách các vị trí còn trống
            var availableSpaces = _context.StorageSpaces
                .Where(s => s.StorageOrdersId == null) // Chưa có đơn hàng
                .OrderBy(s => s.Floor) // Sắp xếp theo tầng để gán hợp lý
                .Take(adminStorageViewModel.Quantity) // Lấy đúng số lượng cần
                .ToList();

            // Kiểm tra nếu không đủ chỗ chứa
            if (availableSpaces.Count < adminStorageViewModel.Quantity)
            {
                return -1; // Không đủ vị trí lưu trữ
            }

            // Gán đơn hàng vào các vị trí lưu trữ
            foreach (var space in availableSpaces)
            {
                space.StorageOrdersId = order.Id;
                space.LocationStorage = adminStorageViewModel.LocationStorage;
                space.Floor = adminStorageViewModel.Floor;
/*                space.Status = StatusStorage.full; // Đánh dấu vị trí đã được sử dụng
*/            }

            // Cập nhật trạng thái đơn hàng
            order.StatusOrder = StatusOrder.Confirmed;

            // Lưu vào database
            _context.UpdateRange(availableSpaces);
            _context.Update(order);
            _context.SaveChanges();

            return 1; // Thành công
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
                order.Price = adminStorageViewModel.Price;
                order.Quantity = adminStorageViewModel.Quantity;

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

