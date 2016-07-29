namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Log
    {
        public int id { get; set; }

        public int fkUser { get; set; }

        public DateTime dateTime { get; set; }

        [Required]
        [StringLength(500)]
        public string message { get; set; }

        public byte status { get; set; }

        public int type { get; set; }

        public virtual User Users { get; set; }
    }
}
