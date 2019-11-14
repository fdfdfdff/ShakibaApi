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
    public class informationController : ControllerBase
    {
        private IRepositoryAsync<tbl_Information> repository;
        public informationController(IRepositoryAsync<tbl_Information> repository)
        {
            this.repository = repository;
        }

        
       
       [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_Information>> Get()
        {
            var tbl_Information = await repository.Get(c=>c.Id>0);

            if (tbl_Information == null)
            {
                return NotFound();
            }

            return tbl_Information;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(int id, tbl_Information model)
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


    }
}