using CustomerManagement.BusinessLogic.Models.Request;

namespace CustomerManagement.BusinessLogic.Models.Dto
{
    public record ClienteDto : ClienteRequest
    {
        public Guid Id { get; set; }
    }
}
