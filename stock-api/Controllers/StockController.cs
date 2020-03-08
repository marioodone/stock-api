using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using stock_api.Domain.Entities;
using stock_api.Model;
using stock_api.Service.Services;
using stock_api.Service.Validators;

namespace stock_api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IMapper _mapper;
        private StockService service;

        public StockController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
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

                StockViewModel model = _mapper.Map<StockViewModel>(item);

                return new ObjectResult(model);
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
                var list = service.Get();
                var listModel = new List<StockViewModel>();

                for (int i = 0; i < list.Count; i++)
                {
                    listModel.Add(_mapper.Map<StockViewModel>(list[i]));
                }

                return new ObjectResult(listModel);
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
                StockViewModel model = _mapper.Map<StockViewModel>(service.Get(id));

                return new ObjectResult(model);
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
                StockViewModel model = _mapper.Map<StockViewModel>(service.SelectFomCode(code));
                return new ObjectResult(model);
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