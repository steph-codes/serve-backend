using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serve.Core.Models;
using Serve.Domain.DataTransferObjects;
using Serve.Domain.LogicInterfaces;

namespace Serve.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        public CustomerController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }

        [HttpGet]
        public IActionResult GetAllCustomers()
        {

            try
            {
                var customers = _repository.Customer.GetAllCustomers();
                //return Ok(Customers);
                var customerDto = _mapper.Map<IEnumerable<CustomerDto>>(customers);

                return Ok(customerDto);
                //var CustomerDto = Customers.Select(c => new CustomerDto
                //{
                //    Id = c.Id,
                //    //Name = c.Name,
                //    Url = c.Url,
                //    Address = string.Join(' ', c.Address, c.State)
                //}).ToList();
                //return Ok(CustomerDto);
            }

            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error ");
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetCustomer(int id)
        {
            try
            {
                var customer = _repository.Customer.GetCustomer(id, trackChanges: false);
                if (customer == null)
                {
                    return NotFound();
                }
                else
                {
                    var customerDto = _mapper.Map<CustomerDto>(customer);
                    return Ok(customerDto);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Internal Server Error ");
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerForUpdateDto customer)
        {
            try
            {
                if (customer == null)
                {
                    return BadRequest("CustomerDto object is null");
                }

                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid Customer model object sent from client.");
                }

                var customerEntity = _repository.Customer.GetCustomer(id, trackChanges: true);
                if (customerEntity == null)
                {
                    return NotFound($"Customer with id: {id} doesn't exist in the database.");
                }
                _mapper.Map(customer, customerEntity);
                _repository.Customer.UpdateCustomer(customerEntity);
                _repository.Save();
                return Ok("Apppoinment Updated");
                //return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Something went wrong inside UpdateOwner action: {ex.Message}");
            }
        }


    }
}
