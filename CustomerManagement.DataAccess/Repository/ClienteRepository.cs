using CustomerManagement.DataAccess.Context;
using CustomerManagement.DataAccess.Interfaces;
using CustomerManagement.DataAccess.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.DataAccess.Repository
{
    public class ClienteRepository: BaseRepository<Cliente>, IClienteRepository
    {
        public ClienteRepository(CustomerDbContext context): base(context) { }
    }
}
