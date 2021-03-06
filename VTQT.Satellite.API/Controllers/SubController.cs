using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VTQT.Satellite.API.Models;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.Service.SatelliteService.DIUnitOfWork;

namespace VTQT.Satellite.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubController : ControllerBase
    {

        private readonly IUnitOfWork _unitOfWork;

        public SubController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet("GetPaginatedList")]
        public IActionResult GetPaginatedList(int start, int length, [FromQuery(Name = "search[value]")] string page)
        {
            if (string.IsNullOrEmpty(page))
                page = "";
            var list = _unitOfWork.SubscriberRepository.Get(x => x.CustomerName.Contains(page)).Select(x=>new SubscriberViewModel { 
            Id=x.Id,
            Status=x.Status,
            ContractNo=x.ContractNo,
            CustomerAddress=x.CustomerAddress,
            CustomerMobile=x.CustomerMobile,
            CustomerName=x.CustomerName,
            District=x.District,
            PaymentCycleRegisted=x.PaymentCycleRegisted,
            Province=x.Province,          
            ShipPlateNo=x.ShipPlateNo          
            });
            
            return Ok(new { data = list.Skip(start).Take(length).ToList(), t = true, recordsTotal = list.Count(), recordsFiltered = list.Count() });
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_unitOfWork.SubscriberRepository.Get(x => x.Id > 0));
        }
        [HttpGet("{id}")]
        public IActionResult GetById(string id)
        {
            return Ok(_unitOfWork.SubscriberRepository.GetFirst(x => x.Id.Equals(id)));
        }


        [HttpPut]
        public IActionResult Add(Subscriber SubscriberRepository)
        {
            var model = _unitOfWork.SubscriberRepository.GetFirst(x => x.Id.Equals(SubscriberRepository.Id));
            if ( model== null)
            {
                return Ok(0);
            }

            try
            {
                if (ModelState.IsValid)
                {
                    SubscriberRepository.ReferenceId = model.ReferenceId;
                    SubscriberRepository.LastSync = model.LastSync;
                    return Ok(_unitOfWork.SubscriberRepository.Insert(SubscriberRepository));
                }
                else
                    return Ok(0);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            try
            {
                if (!string.IsNullOrEmpty(id))
                    return Ok(_unitOfWork.SubscriberRepository.Delete(x => x.Id.Equals(id)));
                else
                    return Ok(0);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }


        }

        [HttpPatch]
        public IActionResult Update(Subscriber SubscriberRepository)
        {
            try
            {
                if (ModelState.IsValid)
                    return Ok(_unitOfWork.SubscriberRepository.Update(SubscriberRepository));
                else
                    return Ok(0);
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
        }




    }
}
