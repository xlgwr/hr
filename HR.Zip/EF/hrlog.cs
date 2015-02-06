namespace HR.Zip.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("hrlog")]
    public partial class hrlog
    {
        [Key]
        [Column(Order = 0)]
        public long logID { get; set; }

        [StringLength(50)]
        public string logname { get; set; }

        [StringLength(50)]
        public string logContent { get; set; }

        [StringLength(50)]
        public string u_str1 { get; set; }

        [StringLength(50)]
        public string u_str2 { get; set; }

        public decimal? u_dec1 { get; set; }

        public decimal? u_dec2 { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime updateDate { get; set; }

        [StringLength(50)]
        public string createby { get; set; }

        [StringLength(50)]
        public string clientIP { get; set; }
    }
}
