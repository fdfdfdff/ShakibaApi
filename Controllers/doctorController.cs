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
    public class doctorController : ControllerBase
    {
        private IRepositoryAsync<tbl_docter> repository;
        public doctorController(IRepositoryAsync<tbl_docter> repository)
        {
            this.repository = repository;
        }

        
        //  Task<ActionResult<IEnumerable<tbl_docter>>>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_docter>> GetAll()
        {
            return await repository.GetAll();
            
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_docter>> Get(int id)
        {
            var tbl_docter = await repository.Get(id);

            if (tbl_docter == null)
            {
                return NotFound();
            }

            return tbl_docter;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(int id, tbl_docter model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
               await repository.Update(model);
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                    return false;
            }
        }

        
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Post(tbl_docter model)
        {
            try
            {
                await repository.Add(model);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        //[HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var tbl_docter = await repository.Get(id);
            if (tbl_docter == null)
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