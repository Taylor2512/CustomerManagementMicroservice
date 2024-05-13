using AutoMapper;

using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Mappers;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore;

namespace CustomerManagement.BusinessLogic.Services
{
    public class ClienteServices(IClienteRepository clienteRepository, IMapper mapper) : IClienteServices
    {
 

        public async Task<ClienteDto> Create(ClienteRequest request)
        {
            if (clienteRepository.All.Any(e => e.NumeroIdentificacion.Equals(request.NumeroIdentificacion)))
            {
                throw new InvalidOperationException($"El número de identificación '{request.NumeroIdentificacion}' ya está en uso.");
            }

            Cliente cliente = mapper.Map<Cliente>(request);
            clienteRepository.Add(cliente);
            await clienteRepository.SaveChangesAsync();

            return mapper.Map<ClienteDto>(cliente);

        }

        public async Task<bool> Delete(Guid id)
        {
            Cliente? cliente = clienteRepository.FindAll(id);
            if (cliente != null)
            {
                clienteRepository.Delete(cliente);
                await clienteRepository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<ClienteDto>> GetAll(int page = 1, int take = 5)
        {

            IQueryable<ClienteDto> cliente = await clienteRepository.GetAllPaginateAsync<ClienteDto>(mapper, page, take);
            List<ClienteDto> clientesDto = await cliente.ToListAsync();
            return clientesDto;
        }

        public async Task<ClienteDto> GetById(Guid id)
        {
            ClienteDto? endiad = await clienteRepository.FindAllAsync<ClienteDto>(mapper, id);
            return endiad ?? throw new InvalidOperationException("Cliente no fue encontrado");
        }

        public async Task<ClienteDto> Update(Guid id, ClienteRequest request)
        {
            Cliente? entidad = clienteRepository.FindAll(id);

            if (clienteRepository.All.Any(e => id != e.Id && e.NumeroIdentificacion.Equals(request.NumeroIdentificacion)))
            {
                throw new InvalidOperationException($"El número de identificación '{request.NumeroIdentificacion}' ya está en uso.");
            }
            if (entidad != null)
            {
                Cliente entidadUpdate = mapper.MapTo<Cliente>(entidad, request);
                await clienteRepository.UpdateAsync(entidadUpdate);
                return mapper.MapTo<ClienteDto>(entidadUpdate);
            }
            else
            {
                throw new InvalidOperationException($"El Cliente con identificación {id} no fue encontrado");
            }

        }
    }
}
