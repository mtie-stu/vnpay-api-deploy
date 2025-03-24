
using Microsoft.EntityFrameworkCore;
using PDP104.Data;
using PDP104.Models;

namespace PDP104.Service
{
    public interface IWareHousesSvc
    {
        List<WareHouses> GetWareHousesAll();
        WareHouses GetWareHouses(int id);
        int AddWareHouse(WareHouses wareHouses);
        int EditWareHouses(int id, WareHouses wareHouses);


    }
    public class WareHouseSvc : IWareHousesSvc
    {
        protected ApplicationDbContext _context;
        public WareHouseSvc(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<WareHouses> GetWareHousesAll()
        {
            return _context.WareHouses
                .Include(w => w.StorageSpaces) // Bao gồm StorageSpaces để tính toán Space
                .ToList();
        }


        public WareHouses GetWareHouses(int id)
        {
            WareHouses wareHouses = null;
            wareHouses = _context.WareHouses.Find(id); //cách này chỉ dùng cho Khóa chính
            //product = _context.Products.Where(e=>e.Id==id).FirstOrDefault(); //cách tổng quát
            return wareHouses;
        }
        public int AddWareHouse(WareHouses wareHouses)
        {
            int ret = 0;
            try
            {
                _context.Add(wareHouses);

                _context.SaveChanges();
                ret = wareHouses.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
        public int EditWareHouses(int id, WareHouses wareHouses)
        {
            int ret = 0;
            try
            {
                WareHouses _wareHouses = null;
                _wareHouses = _context.WareHouses.Find(id); //cách này chỉ dùng cho Khóa chính

                _wareHouses.Location = wareHouses.Location;
              

                _context.Update(_wareHouses);
                _context.SaveChanges();
                ret = wareHouses.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
