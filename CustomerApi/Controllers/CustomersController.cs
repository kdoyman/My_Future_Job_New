using System.Collections.Generic;
using CustomerApi.Interface;
using CustomerLibrary;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService) { _customerService = customerService; }

        [HttpGet]
        [Route("GetCount")]
        public ActionResult<long> GetCount() =>
             _customerService.GetCount();

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Customer>> Get(int pagenum, int customersPerPage) =>
            _customerService.Get(pagenum, customersPerPage);

        [HttpGet("{id:length(24)}", Name = "GetCustomer")]
        public ActionResult<Customer> Get(string id)
        {
            var custo = _customerService.Get(id);

            if (custo == null)
            {
                Log.Information(" Unable to find a customer with id : "+id);
                return NotFound();
               
            }
            Log.Information("Retrieved a customer with id : "+id);
            return custo;
        }

        [HttpPost]
        public ActionResult<Customer> Create(Customer custo)
        {
            _customerService.Create(custo);

            return CreatedAtRoute("GetCustomer", new { id = custo.Id.ToString() }, custo);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Customer custoIn)
        {
            var custo = _customerService.Get(id);

            if (custo == null)
            {
                return NotFound();
            }

            _customerService.Update(id, custoIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var custo = _customerService.Get(id);

            if (custo == null)
            {
                return NotFound();
            }

            _customerService.Remove(custo.Id);

            return NoContent();
        }

    }
}