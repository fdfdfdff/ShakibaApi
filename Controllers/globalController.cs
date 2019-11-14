using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

namespace RCNClinicApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class globalController : ControllerBase
    {
        private IRepositoryAsync<tblVisit> repository;
        ContextDb db = new ContextDb();
        public globalController(IRepositoryAsync<tblVisit> repository)
        {
            this.repository = repository;
        }

        //api/global/reportDeptors?GeneralGroupId=1271
        [HttpGet("reportDeptors")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<RPTDebtors_Result>> reportDeptors(int? GeneralGroupId)
        {
            
            var query = await db.RPTDebtors_Result.FromSql("RPTDebtors {0}", GeneralGroupId).Where(c => c.remain > 0.0).OrderByDescending(c => c.Id).ToListAsync();
            return query;
        }
        //api/global/dateFrom/dateto
        [HttpGet("{dateFrom}/{dateto}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<RptPayment_Result>> reportpayment(string dateFrom, string dateto)
        {
            var query = await db.RptPayment_Result.FromSql("RptPayment {0},{1}", dateFrom, dateto).OrderByDescending(c => c.Id).ToListAsync();
            return query;
        }
        //api/global/idreception
        [HttpGet("{idreception}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Dossier_Result>> getDossier(long idreception)
        {
            var query = await db.Dossier_Result.FromSql("getDossier {0}", idreception).Where(c => c.pathImage != "").OrderBy(c => c.Id).ToListAsync();
            return query;
        }
        //api/global
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public IEnumerable<string> getyear()
        {
            var lst = repository.GetAll().Result;
            List<string> lstyear = new List<string>();
            foreach (DateTime item in lst.Select(c => c.VisitDate).OrderByDescending(c => c))
                lstyear.Add(MYHelper.PersianDate(item).Substring(0, 4));

            return lstyear.Distinct();
        }

        [HttpGet("changeStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public JsonR changeStatus(long ReceptionId,int IdWaiting,string comment="")
        {
            string today = MYHelper.PersianDate(MYHelper.GetDate());
            DateTime from = MYHelper.DiffDate(today, true).AddDays(-7);
            DateTime to = MYHelper.DiffDate(today, false);
            
            var lst = repository.GetAll().Result;
            tblVisit model =lst.FirstOrDefault(c => c.IdReception == ReceptionId && c.VisitDate >= from && c.VisitDate <= to);
            if (model == null)
            {
                return new JsonR {  Title="Error", Message= "ویزیت به تاریخ امروز وجود ندارد" };
              
            }
            model.IdWaiting = IdWaiting;
            model.tblReception.IdWaiting = IdWaiting;
            if (!string.IsNullOrEmpty(comment))
                model.Comment = comment;
            db.SaveChanges();
            return new JsonR { Title = "Success", Message = "عملیات با موفقیت انجام شد" };
        }
    }


}