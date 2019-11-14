using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RCNClinicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class smsController : ControllerBase
    {
        private IRepositoryAsync<tbl_SMS> repository;
        public smsController(IRepositoryAsync<tbl_SMS> repository)
        {
            this.repository = repository;
        }


        //  Task<ActionResult<IEnumerable<tbl_SMS>>>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_SMS>> GetAll()
        {
            return await repository.GetAll();

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_SMS>> Get(long id)
        {
            var tbl_SMS = await repository.Get(id);

            if (tbl_SMS == null)
            {
                return NotFound();
            }

            return tbl_SMS;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<tbl_SMS>> Put(long id, tbl_SMS model)
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
        public async Task<ActionResult<tbl_SMS>> Post(tbl_SMS model)
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
        public async Task<ActionResult> Delete(long id)
        {
            var tbl_SMS = await repository.Get(id);
            if (tbl_SMS == null)
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