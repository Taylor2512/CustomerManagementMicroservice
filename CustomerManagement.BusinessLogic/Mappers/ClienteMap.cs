using AutoMapper;

using CustomerManagement.BusinessLogic.Models.Dto;
using CustomerManagement.BusinessLogic.Models.Request;
using CustomerManagement.DataAccess.Models;


namespace CustomerManagement.BusinessLogic.Mappers
{
    public class ClienteMap : Profile
    {
        public ClienteMap()
        {
            CreateMap<Cliente, ClienteRequest>().IgnoreIfEmpty();
            CreateMap<Cliente, ClienteDto>().IgnoreIfEmpty();
            CreateMap<ClienteRequest, ClienteDto>().IgnoreIfEmpty();
            CreateMap<Parametros, ParametroDto>().IgnoreIfEmpty();
            CreateMap<Parametros, ParametroRequest>().IgnoreIfEmpty();
            CreateMap<ParametroDto, ParametroRequest>().IgnoreIfEmpty();

        }
    }
}
