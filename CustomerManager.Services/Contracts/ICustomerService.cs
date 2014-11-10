namespace CustomerManager.Services.Contracts
{
    using CustomerManager.Services.DTO;

    public interface ICustomerService
    {
        PagedResult<CustomerDTO> GetPaged(PagedRequest request);
        void Update(CustomerDTO dto);
    }

}