namespace HR.Zip.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("user_mstr")]
    public partial class user_mstrView
    {
        [StringLength(50)]
        public string userID { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [StringLength(50)]
        public string email { get; set; }        

        public DateTime updateDate { get; set; }
        
        [StringLength(50)]
        public string clientIP { get; set; }
    }
}
