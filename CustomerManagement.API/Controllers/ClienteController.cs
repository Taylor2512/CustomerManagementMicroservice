using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;

using Microsoft.AspNetCore.Mvc;

namespace CustomerManagement.API.Controllers
{
    [Route("clientes")]
    [ApiController]
    public class ClienteController(IClienteServices clienteServices) : ControllerBase
    {
        /// <summary>
        ///  Consultar todos los clientes
        /// </summary>
        /// <param name="page"></param>
        /// <param name="take"></param>
        /// <returns></returns>

        [HttpGet]
        public async Task<ActionResult<List<ClienteDto>>> GetAll(int page = 1, int take = 5)
        {
            return await clienteServices.GetAll(page, take);
            // Code to get all clients
        }
        /// <summary>
        /// /clientes: Consultar todos los clientes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpGet("{id}")]
        public async Task<ActionResult<ClienteDto>> GetById(Guid id)
        {
            return await clienteServices.GetById(id);
        }
        /// <summary>
        ///   clientes: Crear un nuevo cliente.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<ClienteDto>> Create(ClienteRequest request)
        {
            return await clienteServices.Create(request);
        }
        /// <summary>
        /// clientes/{id}: Actualizar los datos de un cliente existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<ActionResult<ClienteDto>> Update(Guid id, ClienteRequest request)
        {
            return await clienteServices.Update(id, request);
        }
        /// <summary>
        ///  Eliminar un cliente (según la regla especificada).
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            return await clienteServices.Delete(id);
        }
    }
}
