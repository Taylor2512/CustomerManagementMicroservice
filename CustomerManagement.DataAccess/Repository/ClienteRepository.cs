using CustomerManagement.DataAccess.Context;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;

namespace CustomerManagement.DataAccess.Repository
{
    public class ClienteRepository(CustomerDbContext context) : BaseRepository<Cliente>(context), IClienteRepository
    {
    }
}
