namespace CustomerManager.Services.Implementation
{
    using System;
    using System.Linq;
    using AutoMapper.QueryableExtensions;
    using CustomerManager.Data;
    using CustomerManager.Services.Contracts;
    using CustomerManager.Services.DTO;
    
    public class CustomerService : ICustomerService
    {
        private readonly IRepository repository;

        public CustomerService(IRepository repository)
        {
            this.repository = repository;
        }
        
        public PagedResult<CustomerDTO> GetPaged(PagedRequest request)
        {
            var entities = this.repository.Query<Customer>().OrderBy(c => c.CompanyName);
            
            return new PagedResult<CustomerDTO>
            {
                Total = entities.Count(),
                Data = entities.Skip(request.Page * request.PageSize).Take(request.PageSize).Project().To<CustomerDTO>()
            };
        }

        public void Update(CustomerDTO dto)
        {
            if (string.IsNullOrEmpty(dto.CustomerId))
            {
                throw new Exception("CustomerId is required");
            }

            if (string.IsNullOrEmpty(dto.ContactName))
            {
                throw new Exception("ContactName can not be null or empty");
            }

            if (dto.ContactName.Length < 2)
            {
                throw new Exception("ContactName should contains at least to characters");
            }
            
            var entity = this.repository.Query<Customer>().FirstOrDefault(c => c.CustomerId == dto.CustomerId);
            if (entity != null)
            {
                AutoMapper.Mapper.Map(dto, entity);
                this.repository.SaveChanges();
            }
            else
            {
                throw new Exception(string.Format("Customer with id: {0} is not found", dto.CustomerId));
            }
        }
    }
}