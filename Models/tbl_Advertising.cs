namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Advertising
    {
        public long Id { get; set; }

        public long IdVisit { get; set; }

        public DateTime SendDate { get; set; }

        public bool? IsSend { get; set; }

        public int? IdService { get; set; }

        public virtual tbl_Service tbl_Service { get; set; }

        public virtual tblVisit tblVisit { get; set; }
    }
}
