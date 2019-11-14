namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_InsureAccount
    {
        public long Id { get; set; }

        public DateTime? Date { get; set; }

        public int? IdInsurence { get; set; }

        public double? Price { get; set; }

        public string Description { get; set; }

        public int? WhoSave { get; set; }

        public DateTime? DateSave { get; set; }

        public int? WhoEdit { get; set; }

        public DateTime? DateEdit { get; set; }

        public virtual tbl_Insure tbl_Insure { get; set; }

        public virtual tbl_Users tbl_UserEdit { get; set; }

        public virtual tbl_Users tbl_UsersSave { get; set; }
    }
}
