namespace CustomerManager
{
    using AutoMapper;

    using CustomerManager.Data;
    using CustomerManager.Services.DTO;

    public static class AutoMapperConfig
    {
        /// <summary>
        /// Configures this instance.
        /// </summary>
        public static void Configure()
        {
           Mapper.CreateMap<Customer, CustomerDTO>();
           Mapper.CreateMap<CustomerDTO, Customer>();
        }
    }
}