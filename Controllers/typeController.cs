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
    public class typeController : ControllerBase
    {
        private IRepositoryAsync<tbl_Type> repository;
        public typeController(IRepositoryAsync<tbl_Type> repository)
        {
            this.repository = repository;
        }


        //  Task<ActionResult<IEnumerable<tbl_Type>>>
       

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_Type>> Get(int id)
        {
            var tbl_Type = await repository.Get(id);

            if (tbl_Type == null)
            {
                return NotFound();
            }

            return tbl_Type;
        }


        
    }
}