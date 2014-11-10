namespace CustomerManager.Controllers.api
{
    using System;
    using System.Web.Http;

    using CustomerManager.Models;
    using CustomerManager.Services;
    using CustomerManager.Services.Contracts;
    using CustomerManager.Services.DTO;

    [RoutePrefix("customer")]
    public class CustomerController: ApiController
    {
        private readonly ICustomerService customerService;

        public CustomerController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult Get(int page, int count)
        {
            try
            {
                return this.Ok(new OkApiResponseWithData<PagedResult<CustomerDTO>>(this.customerService.GetPaged(new PagedRequest(page, count))));
            }
            catch (Exception ex)
            {
                return this.Ok(new ErrorApiResponse(ex.Message));
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put(CustomerDTO dto)
        {
            try
            {
                this.customerService.Update(dto);
                return this.Ok(new OkApiResponse());
            }
            catch (Exception ex)
            {
                return this.Ok(new ErrorApiResponse(ex.Message));
            }
        }
    }
}