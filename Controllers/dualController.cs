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
    public class dualController : ControllerBase
    {
        private IRepositoryAsync<tbl_Dual> repository;
        public dualController(IRepositoryAsync<tbl_Dual> repository)
        {
            this.repository = repository;
        }




        ///api/dual/{TypeId}
        [HttpGet("{TypeId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_Dual>> GetAll(int? TypeId)
        {

            return await repository.GetAll((c => c.TypeId == TypeId));

        }




        //[HttpGet("{city}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<IActionResult> GetAll(string city)
        //{
        //    ContextDb db = new ContextDb();
        //    var query = await db.tbl_Type.Join(db.tbl_Dual, c => c.Id, d => d.TypeId, (c, d) => new myclass { Id = c.Id, Name = c.Name, dualName = d.Name }).ToListAsync();
        //    return Ok(query);


        //}

        ///api/dual/Find?id=1
        [HttpGet("Find")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_Dual>> Find(int id)
        {
            var tbl_Dual = await repository.Get(id);

            if (tbl_Dual == null)
            {
                return NotFound();
            }

            return tbl_Dual;
        }


        [HttpPut("{id}")]
        
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(int id, tbl_Dual model)
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
        public async Task<ActionResult<bool>> Post(tbl_Dual model)
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
       
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(int id)
        {
            var tbl_Dual = await repository.Get(id);
            if (tbl_Dual == null)
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