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
    public class accountController : ControllerBase
    {
        private IRepositoryAsync<tbl_Account> repository;
        public accountController(IRepositoryAsync<tbl_Account> repository)
        {
            this.repository = repository;
        }

        
        //  Task<ActionResult<IEnumerable<tbl_Account>>>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_Account>> GetAll()
        {
            return await repository.GetAll();
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_Account>> Get(int id)
        {
            var tbl_Account = await repository.Get(id);

            if (tbl_Account == null)
            {
                return NotFound();
            }

            return tbl_Account;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<tbl_Account>> Put(int id, tbl_Account model)
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
        public async Task<ActionResult<tbl_Account>> Post(tbl_Account model)
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
            var tbl_Account = await repository.Get(id);
            if (tbl_Account == null)
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