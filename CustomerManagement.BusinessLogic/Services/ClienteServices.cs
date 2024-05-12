 using AutoMapper.QueryableExtensions;

using CustomerManagement.BusinessLogic.Interfaces;
using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;

using Microsoft.EntityFrameworkCore;
using CustomerManagement.BusinessLogic.Mappers;
using AutoMapper;

namespace CustomerManagement.BusinessLogic.Services
{
    internal class ClienteServices : IClienteServices
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
            var cliente = _mapper.Map<Cliente>(request);
            _clienteRepository.Add(cliente);
            await _clienteRepository.SaveChangesAsync();

            return _mapper.Map<ClienteDto>(cliente);

         }

        public async Task<bool> Delete(Guid id)
        {
            var cliente= _clienteRepository.FindAll(id);
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

        public  async Task<List<ClienteDto>> GetAll(int page = 1, int take = 5)
        {

            var cliente = await  _clienteRepository.GetAllPaginateAsync<ClienteDto>(_mapper,page, take);
               


            return await cliente.ToListAsync();
        }

        public async Task<ClienteDto> GetById(Guid id)
        {
            var endiad= await _clienteRepository.FindAllAsync<ClienteDto>(_mapper, id);
            if (endiad != null)
                return endiad;
            throw new ArgumentException("Cliente no fue encontrado");
        }

        public async Task<ClienteDto> Update(Guid id, ClienteRequest request)
        {
            var entidad= _clienteRepository.FindAll( id);
            if (entidad != null)
            {
                var entidadUpdate = _mapper.MapTo<Cliente>(entidad, request);
                await _clienteRepository.UpdateAsync(entidadUpdate);
                return _mapper.MapTo<ClienteDto>(entidadUpdate);
            }
            else
            {
                throw new ArgumentException($"El Cliente con identificación {id} no fue encontrado");
            }

        }
    }
}
