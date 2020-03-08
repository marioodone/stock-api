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

namespace History_api.Controllers
{
    [Produces("aplication/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private HistoryService service;

        public HistoryController(IConfiguration configuration)
        {
            service = new HistoryService(configuration);
        }

        public IActionResult Post([FromBody] History item)
        {
            try
            {
                service.Post<HistoryValidator>(item);
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

        public IActionResult Put([FromBody] History item)
        {
            try
            {
                service.Put<HistoryValidator>(item);
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

        public IActionResult GetFromStock(int idStock)
        {
            try
            {
                return new ObjectResult(service.SelectAllFromStock(idStock));
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