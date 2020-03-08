using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;
using stock_api.Service.Services;
using stock_api.Service.Validators;

namespace stock_api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private StockService service;

        public StockController(IConfiguration configuration)
        {
            service = new StockService(configuration);
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] Stock item)
        {
            try
            {
                service.Post<StockValidator>(item);
                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody] Stock item)
        {
            try
            {
                service.Put<StockValidator>(item);
                return new ObjectResult(item.Id);
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Delete(id);
                return new NoContentResult();
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("Get")]
        public IActionResult Get()
        {
            try
            {               
                return new ObjectResult(service.Get());
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetById")]
        public IActionResult Get(int id)
        {
            try
            {
                return new ObjectResult(service.Get(id));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetByCode")]
        public IActionResult Get(string code)
        {
            try
            {
                return new ObjectResult(service.SelectFomCode(code));
            }
            catch (ArgumentNullException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}