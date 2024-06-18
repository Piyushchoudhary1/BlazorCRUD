using BlazorCrud.Server.Interfaces;
using BlazorCrud.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCrud.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IEmployee _employeeService;

        public CityController(IEmployee employeeService)
        {
            _employeeService = employeeService;
        }



        [HttpPost]
        public void Post(City city)
        {
            _employeeService.AddCity(city);
        }

        [HttpPut]
        public void Put(City city)
        {
            _employeeService.UpdateCity(city);
        }

        //this comment is to test the push into the remote repository

    }
}
