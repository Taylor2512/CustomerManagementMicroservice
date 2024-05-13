using CustomerManagement.DataAccess.Context;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;

namespace CustomerManagement.DataAccess.Repository
{
    public class ClienteRepository : BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CustomerDbContext context) : base(context) { }
    }
}
