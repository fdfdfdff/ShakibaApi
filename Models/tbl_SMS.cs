namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    public partial class tbl_SMS
    {
        public long Id { get; set; }

        public long IdVisit { get; set; }

        public DateTime SendDate { get; set; }

        public bool? IsSend { get; set; }

        public virtual tblVisit tblVisit { get; set; }
    }
}
