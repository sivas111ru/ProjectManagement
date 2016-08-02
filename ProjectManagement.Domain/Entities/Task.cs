namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            TasksHistory = new HashSet<TaskHistory>();
            UsersTasksMap = new HashSet<UserTaskMap>();
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

        public virtual Project Projects { get; set; }

        public virtual TasksStatus TasksStatuses { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TaskHistory> TasksHistory { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserTaskMap> UsersTasksMap { get; set; }
    }
}
