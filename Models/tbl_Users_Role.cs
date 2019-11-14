namespace RCNClinicApp
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class tbl_Users_Role
    {
        public long Id { get; set; }

        public int RoleId { get; set; }

        public int UsersId { get; set; }

        public virtual tbl_Dual tbl_Dual { get; set; }

        public virtual tbl_Users tbl_Users { get; set; }
    }
}
