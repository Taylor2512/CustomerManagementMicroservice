using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;

using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteServices;

        public ClienteController(IClienteServices clienteServices)
        {
            _clienteServices = clienteServices;
        }

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetAll(int page = 1, int take = 5)
        {
            return await _clienteServices.GetAll(page, take);
            // Code to get all clients
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(Guid id)
        {
            return await _clienteServices.GetById(id);
        }

        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create(ClienteRequest request)
        {
            return await _clienteServices.Create(request);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> Update(Guid id, ClienteRequest request)
        {
            return await _clienteServices.Update(id, request);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await _clienteServices.Delete(id);
        }
    }
}
