//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    
    public partial class Task
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Task()
        {
            this.TasksHistories = new HashSet<TasksHistory>();
            this.UsersTasksMaps = new HashSet<UsersTasksMap>();
        }
    
        public int id { get; set; }
        public int fkProject { get; set; }
        public bool active { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int fkPriority { get; set; }
        public int status { get; set; }
        public System.DateTime startDate { get; set; }
        public Nullable<System.DateTime> endDate { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual TasksPriority TasksPriority { get; set; }
        public virtual TasksStatus TasksStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TasksHistory> TasksHistories { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsersTasksMap> UsersTasksMaps { get; set; }
    }
}
