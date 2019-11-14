﻿using System;
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
    public class receptionController : ControllerBase
    {
        private IRepositoryAsync<tblReception> repository;

        public receptionController(IRepositoryAsync<tblReception> repository)
        {
            this.repository = repository;
        }




        [HttpGet("{fromDate}/{toDate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tblReception>> GetAll(DateTime fromDate, DateTime toDate)
        {
            return await repository.GetAll(c => c.RegDate >= fromDate && c.RegDate <= toDate);

        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tblReception>> Get(long id)
        {
            var tblReception = await repository.Get(id);

            if (tblReception == null)
            {
                return NotFound();
            }

            return tblReception;
        }


        [HttpPut("{id}")]
        // [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(long id, tblReception model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                ContextDb db = new ContextDb();
                tbl_patient patient = model.tbl_patient;
                if (patient.Id <= 0)
                {
                    string dossier = string.Empty;
                    if (db.tbl_patient.Count() > 0)
                        dossier = (Convert.ToInt64(db.tbl_patient.Max(c => c.DossierNumberPermanent)) + 1).ToString().PadLeft(6, '0');

                    else

                        dossier = "000001";
                    patient.DossierNumberPermanent = dossier;

                    db.tbl_patient.Add(patient);
                }
                else
                    db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                 model.IdPatient = patient.Id;
                model.tbl_patient = null;
                var lstvisit = model.tblVisits;
                lstvisit.Where(c=>c.Id<1).ToList().ForEach(c => { c.IdWaiting = 4; c.DateRequest = MYHelper.GetDate();c.IdReception = model.Id;c.VisitDate = MYHelper.GetDate(c.FarsiDate); });
                db.tblVisits.AddRange(lstvisit);

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
        public async Task<ActionResult<bool>> Post(tblReception model)
        {
            try
            {
                ContextDb db = new ContextDb();
                tbl_patient patient = model.tbl_patient;
                if (patient.Id <= 0)
                {
                    string dossier = string.Empty;
                    if (db.tbl_patient.Count() > 0)
                        dossier = (Convert.ToInt64(db.tbl_patient.Max(c => c.DossierNumberPermanent)) + 1).ToString().PadLeft(6, '0');

                    else

                        dossier = "000001";
                    patient.DossierNumberPermanent = dossier;
                    db.tbl_patient.Add(patient);
                }
                else
                    db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                model.IdPatient = patient.Id;
                model.tbl_patient = null;
                model.IdWaiting = 4;
                model.RegDate = MYHelper.GetDate();
                model.IdGeneralGroup = 1;
                //var lstvisit = model.tblVisits;
                model.tblVisits.ToList().ForEach(c => { c.IdWaiting = 4; c.DateRequest = MYHelper.GetDate();c.IdReception = model.Id;c.VisitDate = MYHelper.GetDate(c.FarsiDate); });

                await repository.Add(model);
                return true;
            }
            catch (Exception err)
            {
                return false;
            }
        }

        [HttpDelete("{id}")]
        //[HttpDelete]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> Delete(long id)
        {
            var tblReception = await repository.Get(id);
            if (tblReception == null)
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