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
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteRepository;
        private readonly IMapper _mapper;

        public ClienteServices(IClienteRepository clienteRepository, IMapper mapper)
        {
            _clienteRepository = clienteRepository;
            _mapper = mapper;
        }

        public async Task<ClienteDto> Create(ClienteRequest request)
        {
            if (_clienteRepository.All.Any(e => e.NumeroIdentificacion.Equals(request.NumeroIdentificacion)))
            {
                throw new InvalidOperationException($"El número de identificación '{request.NumeroIdentificacion}' ya está en uso.");
            }

            Cliente cliente = _mapper.Map<Cliente>(request);
            _clienteRepository.Add(cliente);
            await _clienteRepository.SaveChangesAsync();

            return _mapper.Map<ClienteDto>(cliente);

        }

        public async Task<bool> Delete(Guid id)
        {
            Cliente? cliente = _clienteRepository.FindAll(id);
            if (cliente != null)
            {
                _clienteRepository.Delete(cliente);
                await _clienteRepository.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }

        }

        public async Task<List<ClienteDto>> GetAll(int page = 1, int take = 5)
        {

            IQueryable<ClienteDto> cliente = await _clienteRepository.GetAllPaginateAsync<ClienteDto>(_mapper, page, take);
            List<ClienteDto> clientesDto= await cliente.ToListAsync();
            return clientesDto;
        }

        public async Task<ClienteDto> GetById(Guid id)
        {
            ClienteDto? endiad = await _clienteRepository.FindAllAsync<ClienteDto>(_mapper, id);
            return endiad != null ? endiad : throw new InvalidOperationException("Cliente no fue encontrado");
        }

        public async Task<ClienteDto> Update(Guid id, ClienteRequest request)
        {
            Cliente? entidad = _clienteRepository.FindAll(id);

            if (_clienteRepository.All.Any(e => id != e.Id && e.NumeroIdentificacion.Equals(request.NumeroIdentificacion)))
            {
                throw new InvalidOperationException($"El número de identificación '{request.NumeroIdentificacion}' ya está en uso.");
            }
            if (entidad != null)
            {
                Cliente entidadUpdate = _mapper.MapTo<Cliente>(entidad, request);
                await _clienteRepository.UpdateAsync(entidadUpdate);
                return _mapper.MapTo<ClienteDto>(entidadUpdate);
            }
            else
            {
                throw new InvalidOperationException($"El Cliente con identificación {id} no fue encontrado");
            }

        }
    }
}
