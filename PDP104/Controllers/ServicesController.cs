using Microsoft.AspNetCore.Mvc;
using PDP104.Data;
using PDP104.ViewModel;
using PDP104.Service;
using System.Collections.Generic;

namespace PDP104.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IServicesSvc _servicesSvc;

        public ServicesController(IServicesSvc servicesSvc)
        {
            _servicesSvc = servicesSvc;
        }

        [HttpGet]
        public ActionResult<List<ServicesViewModel>> GetAll()
        {
            var list = _servicesSvc.GetAllServices();
            return Ok(list);
        }

        [HttpGet("{id}")]
        public ActionResult<ServicesViewModel> Get(int id)
        {
            var service = _servicesSvc.GetService(id);
            if (service == null) return NotFound();
            return service;
        }

        [HttpPost]
        public ActionResult<int> Add([FromBody] ServicesViewModel serviceVm)
        {
            var id = _servicesSvc.AddService(serviceVm); // Chỉ gọi 1 lần

            if (id == 0) return BadRequest();

            return Ok(id); // Trả về ID của dịch vụ vừa tạo
        }

        [HttpPut("{id}")]
        public ActionResult<int> Edit(int id, [FromBody] ServicesViewModel serviceVm)
        {
            var result = _servicesSvc.EditService(id, serviceVm);
            if (result == 0) return NotFound();
            return Ok(result);
        }
    }


}
