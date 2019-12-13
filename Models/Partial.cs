using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace RCNClinicApp
{

    public class JsonR
    {
        public string Title { get; set; }
        public string Message  { get; set; }
    }

    public class GetVisitListResult
    {
        public long ReceptionId { get; set; }
        public long patientId { get; set; }
        public string FullName { get; set; }
        public int? IdWaitingVisitCurrent { get; set; }
        public long VisitCurrentId { get; set; }
        public DateTime DateCurrent { get; set; }
        public string DossierNumberPermanent { get; set; }
        public string Tel { get; set; }
        public string service { get; set; }
        public string Date1 { get; set; }
        public int? IdWaiting1 { get; set; }
        public string Date2 { get; set; }
        public int? IdWaiting2 { get; set; }
        public string Date3 { get; set; }
        public int? IdWaiting3 { get; set; }
        public string Date4 { get; set; }
        public int? IdWaiting4 { get; set; }
        public string Date5 { get; set; }
        public int? IdWaiting5 { get; set; }
        public string Date6 { get; set; }
        public int? IdWaiting6 { get; set; }
        public string Date7 { get; set; }
        public int? IdWaiting7 { get; set; }
        public string Date8 { get; set; }
        public int? IdWaiting8 { get; set; }
        public string Date9 { get; set; }
        public int? IdWaiting9 { get; set; }
        public string Date10 { get; set; }
        public int? IdWaiting10 { get; set; }
    }

    public partial class RPTDebtors_Result
    {
        public long Id { get; set; }
        public string DossierNumberPermanent { get; set; }
        public string Name { get; set; }
        public string regDate { get; set; }
        public Nullable<double> Total { get; set; }
        public double paid { get; set; }
        public double pay { get; set; }
        public double remain { get; set; }
        public System.DateTime Date { get; set; }
    }

    public partial class RptPayment_Result
    {
        public long Id { get; set; }
        public int GeneralId { get; set; }
        public string GroupName { get; set; }
        public string DossierNumberPermanent { get; set; }
        public string Name { get; set; }
        public string receptionDate { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<double> Total { get; set; }
        public Nullable<double> pay { get; set; }
        public Nullable<int> IdPayType { get; set; }
        public string payType { get; set; }
        public string DatePay { get; set; }
        public Nullable<double> totalpay { get; set; }
        public Nullable<double> Sterdad { get; set; }
        public Nullable<double> remain { get; set; }
    }

    public partial class Dossier_Result
    {
        public long Id { get; set; }
        public string title { get; set; }
        public string pathImage { get; set; }
       
    }

    public class MYHelper
    {

        public static int[] arrayNumPos = new int[] { 8, 0x2e, 0x30, 0x31, 50, 0x33, 0x34, 0x35, 0x36, 0x37, 0x38, 0x39, 0x2b };

        
        public static string todayDate { get; set; }

        public static int General_GroupId { get; set; }

        

       

       

        public static DateTime DiffDate(string date, bool ismin)
        {
            char[] separator = new char[] { '/' };
            string[] strArray = date.Split(separator);
            PersianCalendar calendar = new PersianCalendar();
            if (ismin)
            {
                return calendar.ToDateTime(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), 0, 0, 0, 0);
            }
            return calendar.ToDateTime(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), 0x17, 0x3b, 0x3b, 0x3e7);
        }

       

        public static DateTime GetDate()
        {
            return DateTime.Now;
        }

        public static DateTime GetDate(string str)
        {
            char[] separator = new char[] { '/' };
            string[] strArray = str.Split(separator);
            DateTime now = DateTime.Now;
            PersianCalendar calendar = new PersianCalendar();
            return calendar.ToDateTime(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), now.Hour, now.Minute, now.Second, now.Millisecond);
        }

        public static DateTime GetDate(string str, int Hour, int Minute, int Second)
        {
            char[] separator = new char[] { '/' };
            string[] strArray = str.Split(separator);
            DateTime now = DateTime.Now;
            PersianCalendar calendar = new PersianCalendar();
            return calendar.ToDateTime(int.Parse(strArray[0]), int.Parse(strArray[1]), int.Parse(strArray[2]), Hour, Minute, Second, 0);
        }

        

        public static double GetMaxMin(double[] Array, bool IsMax = true)
        {
            int num3;
            double num = Array[0];
            for (int i = 1; i < Array.Length; i = num3 + 1)
            {
                num = IsMax ? Math.Max(num, Array[i]) : Math.Min(num, Array[i]);
                num3 = i;
            }
            return num;
        }

       
        
       
      

        public static System.Data.DataTable EntityToDataTable(string commandtext, string ConnectionString)
        {
            System.Data.DataTable table2;
            try
            {

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    using (SqlCommand command = new SqlCommand(commandtext, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            using (System.Data.DataTable table = new System.Data.DataTable())
                            {
                                adapter.Fill(table);
                                table2 = table;
                            }
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return table2;
        }
     

        public static string PersianDate(DateTime date)
        {
            if (date.ToShortDateString() == "1/1/0001")
            {
                return "";
            }
            PersianCalendar calendar = new PersianCalendar();
            object[] objArray1 = new object[] { calendar.GetYear(date), "/", calendar.GetMonth(date).ToString().PadLeft(2, '0'), "/", calendar.GetDayOfMonth(date).ToString().PadLeft(2, '0') };
            return string.Concat(objArray1);
        }

        public static string getMonthName(int i)
        {
            string result = "";
            switch (i)
            {
                case 1:
                    result = "فروردین";
                    break;
                case 2:
                    result = "اردیبهشت";
                    break;
                case 3:
                    result = "خرداد";
                    break;
                case 4:
                    result = "تیر";
                    break;
                case 5:
                    result = "مرداد";
                    break;
                case 6:
                    result = "شهریور";
                    break;
                case 7:
                    result = "مهر";
                    break;
                case 8:
                    result = "آبان";
                    break;
                case 9:
                    result = "آذر";
                    break;
                case 10:
                    result = "دی";
                    break;
                case 11:
                    result = "بهمن";
                    break;
                case 12:
                    result = "اسفند";
                    break;
                default:

                    break;
            }
            return result;
        }


        public static long getIdVisitbyIdReception(long IdReception, string date)
        {

            long IdVisit = -1;
            date = string.IsNullOrEmpty(date) ? "" : date.Replace('_', '/');
            if (!string.IsNullOrEmpty(date) && date.Contains("/"))
            {
                DateTime from = MYHelper.DiffDate(date, true);
                DateTime to = MYHelper.DiffDate(date, false);
                ContextDb db = new ContextDb();
                var model = db.tblVisits.FirstOrDefault(c => c.IdReception == IdReception && c.VisitDate >= from && c.VisitDate <= to);
                if (model != null)
                    IdVisit = model.Id;
            }
            return IdVisit;
        }

    }

    partial class tblVisit
    {
        ContextDb dd = new ContextDb();
        //public string PersianDate
        //{
        //    get
        //    {
        //        return MYHelper.PersianDate(this.VisitDate);
        //    }
        //}
        [NotMapped]
        public string FarsiDate { get; set; }
        public string TotalMeeting
        {

            get
            {
                var qq = dd.tblVisits.Where(c => c.IdReception == this.IdReception);
                var visit = dd.tblVisits.Find(this.Id);
                return " جلسه " + (qq.ToList().IndexOf(visit) + 1);
            }
        }
    }

    partial class tblPicture
    {
        [NotMapped]
        public IFormFile Image { get; set; }

        [NotMapped]
        public long IdReception { get; set; }

        [NotMapped]
        public string date { get; set; }

    }

    public class reportvisit_result
    {
        public int Row { get; set; }
        public string FullName { get; set; }
        public string Dossier { get; set; }
        public string Tel { get; set; }
        public string service { get; set; }
        public string total { get; set; }
        public string Comment { get; set; }
        public string PersianDate { get; set; }

        public double? Payment { get; set; }
       

    }

    public class chartvisit_result
    {
        public string Month { get; set; }
        public int IsDo { get; set; }

        public int IsNotDo { get; set; }


    }
}
