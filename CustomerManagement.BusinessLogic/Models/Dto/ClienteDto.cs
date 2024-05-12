using CustomerManagement.BusinessLogic.Models.Request;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManagement.BusinessLogic.Models.Dto
{
    public record ClienteDto: ClienteRequest
    {
        public Guid Id { get; set; }
    }
}
