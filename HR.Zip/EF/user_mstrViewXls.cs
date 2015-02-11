namespace HR.Zip.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class user_mstrViewXls
    {

        public long Tid { get; set; }

        [StringLength(50)]
        public string userID { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string email { get; set; }

        [StringLength(256)]
        public string password { get; set; }

        [StringLength(256)]
        public string cc_super { get; set; }

        [StringLength(256)]
        public string cc_hr { get; set; }
    }
}
