using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;

using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController(IClienteServices clienteServices) : ControllerBase
    {
 
        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetAll(int page = 1, int take = 5)
        {
            return await clienteServices.GetAll(page, take);
            // Code to get all clients
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(Guid id)
        {
            return await clienteServices.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create(ClienteRequest request)
        {
            return await clienteServices.Create(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> Update(Guid id, ClienteRequest request)
        {
            return await clienteServices.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await clienteServices.Delete(id);
        }
    }
}
