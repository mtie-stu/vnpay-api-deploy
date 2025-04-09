using PDP104.Data;
using PDP104.Models;
using PDP104.ViewModel;


namespace PDP104.Service
{
    public interface IStorageSpacesSvc
    {
        List<StorageSpacesViewModel> GetStorageSpacesAll();
        StorageSpacesViewModel GetStorageSpaces(int id);
        int AddStorageSpace(StorageSpacesViewModel storageSpaces);
        int EditStorageSpaces(int id, StorageSpacesViewModel storageSpaces);
    }

    public class StorageSpaceSvc : IStorageSpacesSvc
    {
        protected ApplicationDbContext _context;
        public StorageSpaceSvc(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<StorageSpacesViewModel> GetStorageSpacesAll()
        {
            return _context.StorageSpaces
                .Select(s => new StorageSpacesViewModel
                {
                    Id = s.Id,
                    Floor = s.Floor,
                    LocationStorage = s.LocationStorage,
                    Status = s.Status,
                    WareHouseId = s.WareHouseId
                }).ToList();
        }

        public StorageSpacesViewModel GetStorageSpaces(int id)
        {
            var storageSpaces = _context.StorageSpaces.Find(id);
            if (storageSpaces == null) return null;

            return new StorageSpacesViewModel
            {
                Id = storageSpaces.Id,
                Floor = storageSpaces.Floor,
                LocationStorage = storageSpaces.LocationStorage,
                Status = storageSpaces.Status,
                WareHouseId = storageSpaces.WareHouseId
            };
        }

        public int AddStorageSpace(StorageSpacesViewModel storageSpacesVm)
        {
            int ret = 0;
            try
            {
                var storageSpaces = new StorageSpaces
                {
                    Floor = storageSpacesVm.Floor,
                    LocationStorage = storageSpacesVm.LocationStorage,
                    Status = StatusStorage.empty,
                    WareHouseId = storageSpacesVm.WareHouseId
                };

                _context.StorageSpaces.Add(storageSpaces);
                _context.SaveChanges();
                ret = storageSpaces.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditStorageSpaces(int id, StorageSpacesViewModel storageSpacesVm)
        {
            int ret = 0;
            try
            {
                var _storageSpaces = _context.StorageSpaces.Find(id);
                if (_storageSpaces == null) return 0;

                _storageSpaces.Floor = storageSpacesVm.Floor;
                _storageSpaces.LocationStorage = storageSpacesVm.LocationStorage;
                _storageSpaces.Status = storageSpacesVm.Status;
                _storageSpaces.WareHouseId = storageSpacesVm.WareHouseId;

                _context.Update(_storageSpaces);
                _context.SaveChanges();
                ret = _storageSpaces.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}
