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

namespace History_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoryController : ControllerBase
    {
        private readonly IMapper _mapper;
        private HistoryService service;

        public HistoryController(IMapper mapper, IConfiguration configuration)
        {
            _mapper = mapper;
            service = new HistoryService(configuration);
        }

        [HttpPost]
        [Route("Post")]
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

        [HttpPut]
        [Route("Put")]
        public IActionResult Put([FromBody] History item)
        {
            try
            {
                service.Put<HistoryValidator>(item);

                HistoryViewModel model = _mapper.Map<HistoryViewModel>(item);

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
                var listModel = new List<HistoryViewModel>();

                for (int i = 0; i < list.Count; i++)
                {
                    listModel.Add(_mapper.Map<HistoryViewModel>(list[i]));
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
                HistoryViewModel model = _mapper.Map<HistoryViewModel>(service.Get(id));

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
        [Route("GetByStockId")]
        public IActionResult GetFromStock(int idStock)
        {
            try
            {
                var list = service.SelectAllFromStock(idStock);
                var listModel = new List<HistoryViewModel>();

                for (int i = 0; i < list.Count; i++)
                {
                    listModel.Add(_mapper.Map<HistoryViewModel>(list[i]));
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
        [Route("GetByCode")]
        public IActionResult GetFromStockCode(string code)
        {
            try
            {
                var list = service.SelectAllFromStockCode(code);
                var listModel = new List<HistoryViewModel>();

                for (int i = 0; i < list.Count; i++)
                {
                    listModel.Add(_mapper.Map<HistoryViewModel>(list[i]));
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
    }
}