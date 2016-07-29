namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            TasksHistory = new HashSet<TasksHistory>();
            UsersTasksMap = new HashSet<UsersTasksMap>();
        }

        public int id { get; set; }

        public int fkProject { get; set; }

        public bool active { get; set; }

        [Required]
        [StringLength(500)]
        public string name { get; set; }

        [Column(TypeName = "text")]
        public string description { get; set; }

        public byte priority { get; set; }

        public int status { get; set; }

        public DateTime startDate { get; set; }

        public DateTime? endDate { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual TasksStatuses TasksStatuses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TasksHistory> TasksHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersTasksMap> UsersTasksMap { get; set; }
    }
}
