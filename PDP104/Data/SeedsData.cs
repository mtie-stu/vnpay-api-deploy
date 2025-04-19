using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PDP104.Models;

namespace PDP104.Data
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // ✅ Seed ASP.NET Identity Roles
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "1", // bạn có thể dùng Guid.NewGuid().ToString() nếu muốn sinh tự động
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "2",
                    Name = "User",
                    NormalizedName = "USER"
                }
            );

            // ✅ Seed Services
            modelBuilder.Entity<Services>().HasData(
                new Services { Id = 1, NameServices = "Lưu trữ hàng Balet - Ngày", TypeService = TypeService.Balet, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ hàng balet theo ngày", UnitPrice = 100000M },
                new Services { Id = 2, NameServices = "Lưu trữ hàng Balet - Tháng", TypeService = TypeService.Balet, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ hàng balet theo tháng", UnitPrice = 1500000M },
                new Services { Id = 3, NameServices = "Lưu trữ hàng Balet - Năm", TypeService = TypeService.Balet, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ hàng balet theo năm", UnitPrice = 5000000M },
                new Services { Id = 4, NameServices = "Lưu trữ Container 18ft - Ngày", TypeService = TypeService.Container18ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 18ft theo ngày", UnitPrice = 200000M },
                new Services { Id = 5, NameServices = "Lưu trữ Container 18ft - Tháng", TypeService = TypeService.Container18ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 18ft theo tháng", UnitPrice = 1500000M },
                new Services { Id = 6, NameServices = "Lưu trữ Container 18ft - Năm", TypeService = TypeService.Container18ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 18ft theo năm", UnitPrice = 15000000M },
                new Services { Id = 7, NameServices = "Lưu trữ Container 20ft - Ngày", TypeService = TypeService.Container20ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 20ft theo ngày", UnitPrice = 250000M },
                new Services { Id = 8, NameServices = "Lưu trữ Container 20ft - Tháng", TypeService = TypeService.Container20ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 20ft theo tháng", UnitPrice = 2000000M },
                new Services { Id = 9, NameServices = "Lưu trữ Container 20ft - Năm", TypeService = TypeService.Container20ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 20ft theo năm", UnitPrice = 20000000M },
                new Services { Id = 10, NameServices = "Lưu trữ Container 22ft - Ngày", TypeService = TypeService.Container22ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 22ft theo ngày", UnitPrice = 300000M },
                new Services { Id = 11, NameServices = "Lưu trữ Container 22ft - Tháng", TypeService = TypeService.Container22ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 22ft theo tháng", UnitPrice = 2500000M },
                new Services { Id = 12, NameServices = "Lưu trữ Container 22ft - Năm", TypeService = TypeService.Container22ft, StatusService = StatusService.Active, Description = "Dịch vụ lưu trữ Container 22ft theo năm", UnitPrice = 25000000M },
                new Services { Id = 13, NameServices = "Kiểm kê Container 18ft ", TypeService = TypeService.Inventory18ft, StatusService = StatusService.Active, Description = "Dịch vụ Kiểm kê Container 18ft", UnitPrice = 350000M },
                new Services { Id = 14, NameServices = "Kiểm kê Container 20ft ", TypeService = TypeService.Inventory20ft, StatusService = StatusService.Active, Description = "Dịch vụ Kiểm kê Container 20ft", UnitPrice = 450000M },
                new Services { Id = 15, NameServices = "Kiểm kê Container 22ft ", TypeService = TypeService.Inventory22ft, StatusService = StatusService.Active, Description = "Dịch vụ Kiểm kê Container 22ft", UnitPrice = 550000M },
                new Services { Id = 16, NameServices = "Null ", TypeService = TypeService.Balet, StatusService = StatusService.Active, Description = "Balet", UnitPrice = 0M }
            );

            // ✅ Seed Warehouses
            modelBuilder.Entity<WareHouses>().HasData(
                new WareHouses { Id = 1, Location = "VNOS ", Status = StatusWareHouse.Active },
                new WareHouses { Id = 2, Location = "VNIS ", Status = StatusWareHouse.Active }
            );

            // ✅ Seed StorageSpaces
            modelBuilder.Entity<StorageSpaces>().HasData(
                Enumerable.Range(1, 100).Select(i => new StorageSpaces
                {
                    Id = i,
                    Floor = 0,
                    LocationStorage = $"VNOS-{i:D3}-0",
                    Status = StatusStorage.empty,
                    WareHouseId = 1
                })
                .Concat(
                    Enumerable.Range(101, 100).SelectMany(i =>
                        Enumerable.Range(0, 8).Select(floor => new StorageSpaces
                        {
                            Id = i * 10 + floor,
                            Floor = floor,
                            LocationStorage = $"VNIS-{(i - 100):D3}-{floor}",
                            Status = StatusStorage.empty,
                            WareHouseId = 2
                        })
                    )
                ).ToArray()
            );
        }
    }
}
