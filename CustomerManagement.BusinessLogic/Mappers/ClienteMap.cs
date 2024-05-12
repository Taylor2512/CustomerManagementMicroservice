using AutoMapper;

using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;
using CustomerManagement.DataAccess.Models;


namespace CustomerManagement.BusinessLogic.Mappers
{
    internal class ClienteMap:Profile
    {
        public ClienteMap()
        { 
            CreateMap<Cliente,ClienteRequest>().IgnoreIfEmpty();
            CreateMap<Cliente, ClienteDto>().IgnoreIfEmpty();
            CreateMap<ClienteRequest, ClienteDto>().IgnoreIfEmpty();
        
        }
    }
}
