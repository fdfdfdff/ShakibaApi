using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RCNClinicApp.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class transactionController : ControllerBase
    {
        private IRepositoryAsync<tbl_cash_AllTransaction> repository;
        public transactionController(IRepositoryAsync<tbl_cash_AllTransaction> repository)
        {
            this.repository = repository;
        }

        
        //  Task<ActionResult<IEnumerable<tbl_cash_AllTransaction>>>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_cash_AllTransaction>> GetAll()
        {
            return await repository.GetAll(c=>!c.DateDelete.HasValue);
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_cash_AllTransaction>> Get(int id)
        {
            var tbl_cash_AllTransaction = await repository.Get(id);

            if (tbl_cash_AllTransaction == null)
            {
                return NotFound();
            }

            return tbl_cash_AllTransaction;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<tbl_cash_AllTransaction>> Put(int id, tbl_cash_AllTransaction model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
              return await repository.Update(model);
            }
            catch (DbUpdateConcurrencyException)
            {
                    return NoContent();
            }
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<tbl_cash_AllTransaction>> Post(tbl_cash_AllTransaction model)
        {
            try
            {
                return await repository.Add(model);
            }
            catch (Exception)
            {
                return NoContent();
            }
        }

        [HttpDelete("{id}")]
        //[HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var tbl_cash_AllTransaction = await repository.Get(id);
            if (tbl_cash_AllTransaction == null)
            {
                return NotFound();
            }

            try
            {
                await repository.Delete(id);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }


    }
}