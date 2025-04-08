using Microsoft.EntityFrameworkCore;
using PDP104.Data;
using PDP104.Models;
using PDP104.Models.ViewModel;
using PDP104.ViewModel;

namespace PDP104.Service
{
    public interface IAdminStorageOrderSvc
    {
        List<AdminStorageViewModel> GetAllStorageOrder();
        AdminStorageViewModel GetStorageOrder(int id);
        int SetLocationStorageOrder(int orderId/*, AdminStorageViewModel adminStorageViewModel*/);
        int EditOrder(int id, AdminStorageViewModel adminStorageViewModel);
        int ImportingOrder(int id);
        int ExportingOrder(int id);
        List<AdminStorageViewModel> GetAllStorageOrderWhereInventoryActive();

    }
    public class Admin_StorageOrderSvc : IAdminStorageOrderSvc
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

        /* public int SetLocationStorageOrder(int orderId, AdminStorageViewModel adminStorageViewModel)
         {
             Console.WriteLine($"➡ Bắt đầu xử lý SetLocationStorageOrder cho OrderId: {orderId}");

             var order = _context.StorageOrders.FirstOrDefault(o => o.Id == orderId);
             if (order == null)
             {
                 Console.WriteLine($"❌ Lỗi: Không tìm thấy đơn hàng với OrderId: {orderId}");
                 return 0;
             }

             int totalDays = (order.DateOfShipment - order.DateOfEntry).Days;
             Console.WriteLine($"📅 Tổng số ngày lưu trữ: {totalDays}");

             int warehouseId = order.TypeOfGoods == TypeOfGoods.Balet ? 2 : 1;
             Console.WriteLine($"🏢 Xác định kho hàng: {warehouseId}");

             var availableSpaces = _context.StorageSpaces
                 .Where(s => s.StorageOrdersId == null && s.WareHouseId == warehouseId )
                 .OrderBy(s => s.Floor)
                 .Take(order.Quantity)
                 .ToList();

             Console.WriteLine($"📦 Số lượng vị trí trống tìm thấy: {availableSpaces.Count}");

             if (availableSpaces.Count < adminStorageViewModel.Quantity)
             {
                 Console.WriteLine("❌ Lỗi: Không đủ vị trí lưu trữ.");
                 return -1;
             }

             foreach (var space in availableSpaces)
             {
                 space.StorageOrdersId = adminStorageViewModel.Id;
                 space.LocationStorage = adminStorageViewModel.LocationStorage;
                 space.Floor = adminStorageViewModel.Floor;
                 adminStorageViewModel.StatusStorage = StatusStorage.booked;
             }

             var servicesList = new List<int>();
             decimal totalPrice = 0;

             if (totalDays <= 30)
             {
                 int serviceId = GetServiceId(order.TypeOfGoods, "day");
                 if (IsValidService(serviceId))
                 {
                     servicesList.Add(serviceId);
                     totalPrice += GetServicePrice(serviceId) * order.Quantity;
                 }
             }
             else if (totalDays == 365)
             {
                 int serviceId = GetServiceId(order.TypeOfGoods, "year");
                 if (IsValidService(serviceId))
                 {
                     servicesList.Add(serviceId);
                     totalPrice += GetServicePrice(serviceId) * order.Quantity;
                 }
             }
             else
             {
                 int months = totalDays / 30;
                 int days = totalDays % 30;

                 for (int i = 0; i < months; i++)
                 {
                     int serviceId = GetServiceId(order.TypeOfGoods, "month");
                     if (IsValidService(serviceId))
                     {
                         servicesList.Add(serviceId);
                         totalPrice += GetServicePrice(serviceId) * order.Quantity;
                     }
                 }
                 if (days > 0)
                 {
                     int serviceId = GetServiceId(order.TypeOfGoods, "day");
                     if (IsValidService(serviceId))
                     {
                         servicesList.Add(serviceId);
                         totalPrice += GetServicePrice(serviceId) * order.Quantity;
                     }
                 }
             }

             if (order.StatusInventory == StatusInventory.Active)
             {
                 Console.WriteLine("📋 Tạo bản ghi kiểm kê mới.");
                 var newInventory = new Inventory
                 {
                     RequestDate = DateTime.Now,
                     StorageOrdersId = order.Id
                 };
                 _context.Inventories.Add(newInventory);
 *//*                _context.SaveChanges();
 *//*            }

             if (order.StatusInventory == StatusInventory.Active)
             {
                 int serviceId = GetInventoryServiceId(order.TypeOfGoods);
                 if (IsValidService(serviceId))
                 {
                     servicesList.Add(serviceId);
                     totalPrice += GetServicePrice(serviceId) * order.Quantity;
                 }
             }

             Console.WriteLine("📜 Danh sách ServiceId hợp lệ:");
             foreach (var serviceId in servicesList)
             {
                 Console.WriteLine($"✔ ServiceId: {serviceId}");
             }

             var validServiceOrders = servicesList
                 .Where(serviceId => IsValidService(serviceId))
                 .Select(serviceId => new StorageOrderServices
                 {
                     StorageOrderId = order.Id,
                     ServiceId = serviceId
                 }).ToList();

             if (!validServiceOrders.Any())
             {
                 Console.WriteLine("❌ Lỗi: Không có ServiceId hợp lệ để lưu vào StorageOrderServices.");
                 return -6;
             }

             Console.WriteLine("📌 Các ServiceId được thêm vào StorageOrderServices:");
             foreach (var service in validServiceOrders)
             {
                 Console.WriteLine($"✔ StorageOrderId: {service.StorageOrderId}, ServiceId: {service.ServiceId}");
             }

             try
             {
                 _context.StorageOrderServices.AddRange(validServiceOrders);
                 order.StatusOrder = StatusOrder.Confirmed;
                 order.Price = totalPrice;

                 Console.WriteLine($"💰 Tổng giá trị đơn hàng: {totalPrice}");
                 Console.WriteLine($"🔄 Cập nhật trạng thái đơn hàng: {order.StatusOrder}");

                 _context.UpdateRange(availableSpaces);
                 _context.Update(order);
                 _context.SaveChanges();

                 Console.WriteLine("✅ Cập nhật dữ liệu thành công.");
                 return 1;
             }
             catch (Exception ex)
             {
                 Console.WriteLine($"❌ Lỗi khi lưu dữ liệu: {ex.Message}");
                 return -99;
             }
         }*/

        public int SetLocationStorageOrder(int orderId/*, AdminStorageViewModel adminStorageViewModel*/)
        {
            Console.WriteLine($"➡ Bắt đầu xử lý SetLocationStorageOrder cho OrderId: {orderId}");

            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == orderId);
            if (order == null)
            {
                Console.WriteLine($"❌ Lỗi: Không tìm thấy đơn hàng với OrderId: {orderId}");
                return 0;
            }

            int totalDays = (order.DateOfShipment - order.DateOfEntry).Days;
            Console.WriteLine($"📅 Tổng số ngày lưu trữ: {totalDays}");

            int warehouseId = order.TypeOfGoods == TypeOfGoods.Balet ? 2 : 1;
            Console.WriteLine($"🏢 Xác định kho hàng: {warehouseId}");

            var availableSpaces = _context.StorageSpaces
                .Where(s => s.StorageOrdersId == null && s.WareHouseId == warehouseId)
                .OrderBy(s => s.Floor)
                .Take(order.Quantity)
                .ToList();

            Console.WriteLine($"📦 Số lượng vị trí trống tìm thấy: {availableSpaces.Count}");

            if (availableSpaces.Count < order.Quantity)
            {
                Console.WriteLine("❌ Lỗi: Không đủ vị trí lưu trữ.");
                return -1;
            }

            // Kiểm tra StorageOrdersId hợp lệ
            if (!_context.StorageOrders.Any(o => o.Id == order.Id))
            {
                Console.WriteLine("❌ Lỗi: Không tồn tại StorageOrder với Id: " + order.Id);
                return -1;
            }

            // Kiểm tra các giá trị khác như LocationStorage và Floor
            foreach (var space in availableSpaces)
            {
                if (order.Id == null || order.Id == 0)
                {
                    Console.WriteLine("❌ Lỗi: StorageOrdersId không hợp lệ.");
                    return -1;
                }

                if (string.IsNullOrEmpty(space.LocationStorage))
                {
                    Console.WriteLine("❌ Lỗi: LocationStorage không được để trống.");
                    return -1;
                }

             

                // Cập nhật các thuộc tính của các vị trí lưu trữ
                space.StorageOrdersId = order.Id;
               
                space.Status = StatusStorage.booked;

            }

            var servicesList = new List<int>();
            decimal totalPrice = 0;

            // Tính toán giá trị dịch vụ tùy theo số ngày lưu trữ
            if (totalDays <= 30)
            {
                int serviceId = GetServiceId(order.TypeOfGoods, "day");
                if (IsValidService(serviceId))
                {
                    servicesList.Add(serviceId);
                    totalPrice += GetServicePrice(serviceId) * order.Quantity;
                }
            }
            else if (totalDays == 365)
            {
                int serviceId = GetServiceId(order.TypeOfGoods, "year");
                if (IsValidService(serviceId))
                {
                    servicesList.Add(serviceId);
                    totalPrice += GetServicePrice(serviceId) * order.Quantity;
                }
            }
            else
            {
                int months = totalDays / 30;
                int days = totalDays % 30;

                for (int i = 0; i < months; i++)
                {
                    int serviceId = GetServiceId(order.TypeOfGoods, "month");
                    if (IsValidService(serviceId))
                    {
                        servicesList.Add(serviceId);
                        totalPrice += GetServicePrice(serviceId) * order.Quantity;
                    }
                }
                if (days > 0)
                {
                    int serviceId = GetServiceId(order.TypeOfGoods, "day");
                    if (IsValidService(serviceId))
                    {
                        servicesList.Add(serviceId);
                        totalPrice += GetServicePrice(serviceId) * order.Quantity;
                    }
                }
            }

            // Kiểm tra và tạo bản ghi kiểm kê nếu đơn hàng đang hoạt động
            if (order.StatusInventory == StatusInventory.Active)
            {
                Console.WriteLine("📋 Tạo bản ghi kiểm kê mới.");
                var newInventory = new Inventory
                {
                    RequestDate = DateTime.Now,
                    StorageOrdersId = order.Id
                };
                _context.Inventories.Add(newInventory);
            }

            // Tính toán dịch vụ cho việc kiểm kê nếu có
            if (order.StatusInventory == StatusInventory.Active)
            {
                int serviceId = GetInventoryServiceId(order.TypeOfGoods);
                if (IsValidService(serviceId))
                {
                    servicesList.Add(serviceId);
                    totalPrice += GetServicePrice(serviceId) * order.Quantity;
                }
            }

            Console.WriteLine("📜 Danh sách ServiceId hợp lệ:");
            foreach (var serviceId in servicesList)
            {
                Console.WriteLine($"✔ ServiceId: {serviceId}");
            }

            var validServiceOrders = servicesList
                .Where(serviceId => IsValidService(serviceId))
                .Select(serviceId => new StorageOrderServices
                {
                    StorageOrderId = order.Id,
                    ServiceId = serviceId
                }).ToList();

            if (!validServiceOrders.Any())
            {
                Console.WriteLine("❌ Lỗi: Không có ServiceId hợp lệ để lưu vào StorageOrderServices.");
                return -6;
            }

            Console.WriteLine("📌 Các ServiceId được thêm vào StorageOrderServices:");
            foreach (var service in validServiceOrders)
            {
                Console.WriteLine($"✔ StorageOrderId: {service.StorageOrderId}, ServiceId: {service.ServiceId}");
            }

            try
            {
                // Thêm các dịch vụ hợp lệ vào StorageOrderServices
                _context.StorageOrderServices.AddRange(validServiceOrders);
                order.StatusOrder = StatusOrder.Confirmed;
                order.Price = totalPrice;

                Console.WriteLine($"💰 Tổng giá trị đơn hàng: {totalPrice}");
                Console.WriteLine($"🔄 Cập nhật trạng thái đơn hàng: {order.StatusOrder}");

                // Cập nhật các vị trí lưu trữ và đơn hàng
                _context.UpdateRange(availableSpaces);
                _context.Update(order);
                _context.SaveChanges();

                Console.WriteLine("✅ Cập nhật dữ liệu thành công.");
                return 1;
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine($"❌ Lỗi SQL: {ex.InnerException?.Message ?? ex.Message}");
                return -99;
            }
        }

        // Kiểm tra xem ServiceId có tồn tại trong bảng Services không
        private bool IsValidService(int serviceId)
        {
            if (serviceId == 0) return false;
            return _context.Services.Any(s => s.Id == serviceId);
        }

        // Hàm lấy ServiceId theo loại hàng hóa và thời gian lưu trữ
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

        // Hàm lấy ServiceId cho kiểm kê hàng hóa
        private int GetInventoryServiceId(TypeOfGoods typeOfGoods)
        {
            return typeOfGoods switch
            {
                TypeOfGoods.Container18ft => 13,
                TypeOfGoods.Container20ft => 14,
                TypeOfGoods.Container22ft => 15,
                _ => 16
            };
        }

        // Hàm lấy giá của dịch vụ từ bảng Services
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
            var today = DateTime.Today; // Lấy ngày hiện tại, loại bỏ giờ

            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == id);
            if (order == null) return 0; // Nếu đơn hàng không tồn tại

            if (order.DateOfEntry.Date == today) // Chỉ so sánh ngày
            {
                order.StatusOrder = StatusOrder.Imported;

                var storageSpaces = _context.StorageSpaces.Where(s => s.StorageOrdersId == id).ToList();
                foreach (var space in storageSpaces)
                {
                    space.Status = StatusStorage.full;
                }
                _context.UpdateRange(storageSpaces);

                _context.Update(order);

                _context.SaveChanges();
                return 1; // Thành công
            }
            return 0; // Ngày không khớp
        }





        public int ExportingOrder(int id)
        {
            var today = DateTime.Now;

            var order = _context.StorageOrders.FirstOrDefault(o => o.Id == id);
            if (order == null) return 0; // Nếu đơn hàng không tồn tại
            if (order.DateOfShipment.Date == today.Date)
            {
                // Cập nhật ngày xuất hàng và trạng thái đơn hàng
              
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

