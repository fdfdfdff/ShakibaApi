namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_cash_AllTransaction
    {
        public long Id { get; set; }

        public long? IdReception { get; set; }

        public double? payment { get; set; }

        [StringLength(25)]
        public string SerialNum { get; set; }

        public int? IdPayType { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(100)]
        public string payer { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public bool? IsConfirm { get; set; }

        public short? AccountId { get; set; }

        public int? WhoSave { get; set; }

        public DateTime? DateSave { get; set; }

        public int? WhoEdit { get; set; }

        public DateTime? DateEdit { get; set; }

        public DateTime? DateDelete { get; set; }

        public virtual tbl_Account tbl_Account { get; set; }

        public virtual tbl_Users tbl_UserEdit { get; set; }

        public virtual tbl_Users tbl_UsersSave { get; set; }

        public virtual tbl_Dual tbl_Dual { get; set; }

        public virtual tblReception tblReception { get; set; }
    }
}
