using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Web.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace RCNClinicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class visitController : ControllerBase
    {
        private IRepositoryAsync<tblVisit> repository;
        public visitController(IRepositoryAsync<tblVisit> repository)
        {
            this.repository = repository;
        }

        [HttpGet("{fromdate}/{todate}/{LName}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IActionResult GetAll(string fromdate, string todate, string LName)
        {

            ContextDb db = new ContextDb();
            IEnumerable<GetVisitListResult> lst;
            if (!string.IsNullOrEmpty(LName))
            {
                lst = db.tblVisits.Join(db.tblReceptions.Where(c => c.tbl_patient.LastName.Contains(LName)), c => c.IdReception, d => d.Id, (c, d) => new GetVisitListResult
                {
                    Tel = d.tbl_patient.Tel,
                    service = d.tbl_Service.Name,
                    ReceptionId = c.IdReception,
                    VisitCurrentId = c.Id,
                    patientId = d.IdPatient,
                    DateCurrent = c.VisitDate,
                    IdWaitingVisitCurrent = c.IdWaiting,
                    FullName = d.tbl_patient.Name + " " + d.tbl_patient.LastName,
                    DossierNumberPermanent = d.tbl_patient.DossierNumberPermanent
                });
            }
            else
            {
                if (string.IsNullOrEmpty(fromdate))
                {
                    lst = db.tblVisits.Join(db.tblReceptions, c => c.IdReception, d => d.Id, (c, d) => new GetVisitListResult
                    {
                        Tel = d.tbl_patient.Tel,
                        service = d.tbl_Service.Name,
                        ReceptionId = c.IdReception,
                        patientId = d.IdPatient,
                        VisitCurrentId = c.Id,
                        IdWaitingVisitCurrent = c.IdWaiting,
                        DateCurrent = c.VisitDate,
                        FullName = d.tbl_patient.Name + " " + d.tbl_patient.LastName,
                        DossierNumberPermanent = d.tbl_patient.DossierNumberPermanent
                    });
                }
                else
                {
                    DateTime from = MYHelper.DiffDate(fromdate, true);
                    DateTime to = MYHelper.DiffDate(todate, false);
                    lst = db.tblVisits.Where(c => c.VisitDate >= from && c.VisitDate <= to).Join(db.tblReceptions, c => c.IdReception, d => d.Id, (c, d) => new GetVisitListResult
                    {
                        Tel = d.tbl_patient.Tel,
                        service = d.tbl_Service.Name,
                        ReceptionId = c.IdReception,
                        VisitCurrentId = c.Id,
                        patientId = d.IdPatient,
                        DateCurrent = c.VisitDate,
                        IdWaitingVisitCurrent = c.IdWaiting,
                        FullName = d.tbl_patient.Name + " " + d.tbl_patient.LastName,
                        DossierNumberPermanent = d.tbl_patient.DossierNumberPermanent
                    });
                }
            }
            lst = lst.GroupBy(d => d.ReceptionId).Select(d => new GetVisitListResult
            {
                Tel = d.FirstOrDefault().Tel,
                service = d.FirstOrDefault().service,
                ReceptionId = d.Key,
                DateCurrent = d.OrderBy(z => z.DateCurrent).FirstOrDefault().DateCurrent,
                VisitCurrentId = d.OrderBy(z => z.DateCurrent).FirstOrDefault().VisitCurrentId,
                patientId = d.FirstOrDefault().patientId,
                IdWaitingVisitCurrent = d.OrderBy(z => z.DateCurrent).FirstOrDefault().IdWaitingVisitCurrent,
                FullName = d.FirstOrDefault().FullName,
                DossierNumberPermanent = d.FirstOrDefault().DossierNumberPermanent
            });
            lst = lst.Distinct().ToList();
            foreach (var item in lst)
            {
                var lstvisit = db.tblVisits.Where(c => c.IdReception == item.ReceptionId).OrderBy(c => c.VisitDate).ToList();//.Select(c => c.PersianDate);
                for (int i = 1; i <= lstvisit.Count(); i++)
                {
                    tblVisit visit = lstvisit.Skip((i - 1)).Take(1).FirstOrDefault();
                    switch (i)
                    {
                        case 1:
                            item.Date1 = visit.PersianDate;
                            item.IdWaiting1 = visit.IdWaiting;
                            break;
                        case 2:
                            item.Date2 = visit.PersianDate;
                            item.IdWaiting2 = visit.IdWaiting;
                            break;
                        case 3:
                            item.Date3 = visit.PersianDate;
                            item.IdWaiting3 = visit.IdWaiting;
                            break;
                        case 4:
                            item.Date4 = visit.PersianDate;
                            item.IdWaiting4 = visit.IdWaiting;
                            break;
                        case 5:
                            item.Date5 = visit.PersianDate;
                            item.IdWaiting5 = visit.IdWaiting;
                            break;
                        case 6:
                            item.Date6 = visit.PersianDate;
                            item.IdWaiting6 = visit.IdWaiting;
                            break;
                        case 7:
                            item.Date7 = visit.PersianDate;
                            item.IdWaiting7 = visit.IdWaiting;
                            break;
                        case 8:
                            item.Date8 = visit.PersianDate;
                            item.IdWaiting8 = visit.IdWaiting;
                            break;
                        case 9:
                            item.Date9 = visit.PersianDate;
                            item.IdWaiting9 = visit.IdWaiting;
                            break;
                        case 10:
                            item.Date10 = visit.PersianDate;
                            item.IdWaiting10 = visit.IdWaiting;
                            break;

                        default:
                            break;
                    }
                }
            }
            return Ok(lst);
        }

        [HttpGet("{fromdate}/{todate}/{idService}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tblVisit>> GetAll(string fromdate, string todate, int? idService)
        {
            DateTime from = MYHelper.DiffDate(fromdate, true);
            DateTime to = MYHelper.DiffDate(todate,false);
            return await repository.GetAll(c => 
            c.VisitDate >= from && 
            c.VisitDate <= to &&
            (idService.HasValue ? (c.tblReception.IdService == idService) : true)
            );
        }

        [HttpGet("{year}/{idService}/{iddoctor}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tblVisit>> GetAll(string year, int idService=0, int iddoctor=0)
        {
            DateTime from = MYHelper.DiffDate(year + "/01/01", true);
            DateTime to = MYHelper.DiffDate(year + "/12/29", false);
            return await repository.GetAll(c =>
            c.VisitDate >= from &&
            c.VisitDate <= to &&
            (idService>0 ? (c.tblReception.IdService == idService) : true) &&
            (iddoctor > 0 ? (c.tblReception.IdDoctor == iddoctor) : true)
            );
        }


        [HttpGet("{idreception}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<tblVisit>> GetAll(long idreception)
        {
            return await repository.GetAll(c => c.IdReception == idreception);

        }


        [HttpGet("{idreception}/{date}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<tblVisit>> Get(long idreception, DateTime date)
        {
            var tblVisit = await repository.Get(c=>c.IdReception==idreception && c.VisitDate==date);

            if (tblVisit == null)
            {
                return NotFound();
            }

            return tblVisit;
        }

        [HttpPut("{id}")]
        //[HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Put(long id, tblVisit model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            try
            {
                model.VisitDate = MYHelper.GetDate(model.FarsiDate);
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
        public async Task<ActionResult<bool>> Post(tblVisit model)
        {
            try
            {
                model.VisitDate = MYHelper.GetDate(model.FarsiDate);
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
        public async Task<ActionResult> Delete(long id)
        {
            var tblVisit = await repository.Get(id);
            if (tblVisit == null)
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