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
    public class serviceController : ControllerBase
    {
        private IRepositoryAsync<tbl_Service> repository;
        public serviceController(IRepositoryAsync<tbl_Service> repository)
        {
            this.repository = repository;
        }


        //  Task<ActionResult<IEnumerable<tbl_Service>>>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_Service>> GetAll()
        {
            return await repository.GetAll(c=>!c.IsDelete.HasValue || !c.IsDelete.Value);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_Service>> Get(int id)
        {
            var tbl_Service = await repository.Get(id);

            if (tbl_Service == null)
            {
                return NotFound();
            }

            return tbl_Service;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(int id, tbl_Service model)
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
        public async Task<ActionResult<bool>> Post(tbl_Service model)
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
            var tbl_Service = await repository.Get(id);
            if (tbl_Service == null)
            {
                return NotFound();
            }

            try
            {
                tbl_Service.IsDelete = true;
                await repository.Update(tbl_Service);
                return Ok();
            }
            catch (Exception)
            {
                return NoContent();
            }
        }
    }
}