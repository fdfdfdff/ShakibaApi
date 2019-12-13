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
    public class patientController : ControllerBase
    {
        private IRepositoryAsync<tbl_patient> repository;
        public patientController(IRepositoryAsync<tbl_patient> repository)
        {
            this.repository = repository;
        }


        //  Task<ActionResult<IEnumerable<tbl_patient>>>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_patient>> GetAll()
        {
            return await repository.GetAll();

        }


        [HttpGet("{FName}/{LName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tbl_patient>> GetAll(string FName, string LName)
        {

            if (string.IsNullOrEmpty(FName) && string.IsNullOrEmpty(LName))
                return await repository.GetAll();

            else if (string.IsNullOrEmpty(FName) && !string.IsNullOrEmpty(LName))
                return await repository.GetAll(c => c.LastName.Contains(LName));

            else if (!string.IsNullOrEmpty(FName) && string.IsNullOrEmpty(LName))
                return await repository.GetAll(c => c.Name.Contains(FName));

            else
                return await repository.GetAll(c => c.Name.Contains(FName) && c.LastName.Contains(LName));

        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tbl_patient>> Get(long id)
        {
            var tbl_patient = await repository.Get(id);

            if (tbl_patient == null)
            {
                return NotFound();
            }

            return tbl_patient;
        }


        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(long id, tbl_patient model)
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
        public async Task<ActionResult<bool>> Post(tbl_patient model)
        {
            try
            {
                string dossier = string.Empty;
                IEnumerable<tbl_patient> lst = await GetAll();
                if (lst.Count() > 0)
                    dossier = (Convert.ToInt64(lst.Max(c => c.DossierNumberPermanent)) + 1).ToString().PadLeft(6, '0');
                else
                    dossier = "000001";

                model.DossierNumberPermanent = dossier;
                await repository.Add(model);
                return true;
            }

            catch (Exception)
            {
                return false;
            }
        }


    }
}