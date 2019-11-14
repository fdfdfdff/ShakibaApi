using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;

namespace RCNClinicApp.Models
{
    public class ItemRepository : IItemRepository
    {
        private static ConcurrentDictionary<string, Item> items =
            new ConcurrentDictionary<string, Item>();

        public ItemRepository()
        {
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 4", Description = "This is an item description." });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 5", Description = "This is an item description." });
            Add(new Item { Id = Guid.NewGuid().ToString(), Text = "Item 6", Description = "This is an item description." });
        }

        public Item Get(string id)
        {
            return items[id];
        }

        public IEnumerable<Item> GetAll()
        {
            return items.Values;
        }

        public void Add(Item item)
        {
            item.Id = Guid.NewGuid().ToString();
            items[item.Id] = item;
        }

        public Item Find(string id)
        {
            Item item;
            items.TryGetValue(id, out item);

            return item;
        }

        public Item Remove(string id)
        {
            Item item;
            items.TryRemove(id, out item);

            return item;
        }

        public void Update(Item item)
        {
            items[item.Id] = item;
        }

        public IEnumerable<GetVisitListResult> GetVisit()
        {
            string fromdate = ""; string todate = ""; string LName = "";
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
           return lst;
        }
    }
}
