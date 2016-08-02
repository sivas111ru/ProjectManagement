namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TasksHistory")]
    public partial class TaskHistory
    {
        public int id { get; set; }

        public int fkTask { get; set; }

        public int fkUser { get; set; }

        [Required]
        [StringLength(200)]
        public string message { get; set; }

        public int fkTaskHistoryTypes { get; set; }

        public DateTime dateTime { get; set; }

        public virtual Task Tasks { get; set; }

        public virtual TasksHistoryType TasksHistoryTypes { get; set; }

        public virtual User Users { get; set; }
    }
}
