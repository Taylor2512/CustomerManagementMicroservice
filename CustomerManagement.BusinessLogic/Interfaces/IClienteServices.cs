using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BusinessLogic.Interfaces
{
    public interface IClienteServices
    {
        Task<List<ClienteDto>> GetAll(int page=1, int take=5);
        Task<ClienteDto> GetById(Guid id);
        Task<ClienteDto> Create(ClienteRequest request);
        Task<ClienteDto> Update(Guid id, ClienteRequest request);
        Task<bool> Delete(Guid id);
    }
}
