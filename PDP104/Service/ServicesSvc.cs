using PDP104.Data;
using PDP104.ViewModel;
using PDP104.Models;

using System.Collections.Generic;
using System.Linq;

namespace PDP104.Service
{
    public interface IServicesSvc
    {
        List<ServicesViewModel> GetAllServices();
        ServicesViewModel GetService(int id);
        int AddService(ServicesViewModel serviceVm);
        int EditService(int id, ServicesViewModel serviceVm);
    }

    public class ServicesSvc : IServicesSvc
    {
        protected ApplicationDbContext _context;
        public ServicesSvc(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<ServicesViewModel> GetAllServices()
        {
            return _context.Services
                .Select(s => new ServicesViewModel
                {
                    Id=s.Id,
                    NameServices = s.NameServices,
                    TypeService = s.TypeService,
                    StatusService = s.StatusService,
                    UnitPrice = s.UnitPrice
                }).ToList();
        }

        public ServicesViewModel GetService(int id)
        {
            var service = _context.Services.Find(id);
            if (service == null) return null;

            return new ServicesViewModel
            {
                Id=service.Id,
                NameServices = service.NameServices,
                TypeService = service.TypeService,
                StatusService = service.StatusService,
                UnitPrice = service.UnitPrice
            };
        }

        public int AddService(ServicesViewModel serviceVm)
        {
            int ret = 0;
            try
            {
                var service = new Services
                {
                    NameServices = serviceVm.NameServices,
                    TypeService = serviceVm.TypeService,
                    StatusService = 0, // Mặc định giá trị StatusService là 0
                    UnitPrice = serviceVm.UnitPrice
                };

                _context.Services.Add(service);
                _context.SaveChanges();
                ret = service.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }

        public int EditService(int id, ServicesViewModel serviceVm)
        {
            int ret = 0;
            try
            {
                var _service = _context.Services.Find(id);
                if (_service == null) return 0;

                _service.NameServices = serviceVm.NameServices;
                _service.TypeService = serviceVm.TypeService;
                _service.StatusService = serviceVm.StatusService;
                _service.UnitPrice = serviceVm.UnitPrice;

                _context.Update(_service);
                _context.SaveChanges();
                ret = _service.Id;
            }
            catch
            {
                ret = 0;
            }
            return ret;
        }
    }
}

