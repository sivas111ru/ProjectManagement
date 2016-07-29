namespace ProjectManagement.Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsersTasksMap")]
    public partial class UserTaskMap
    {
        public int id { get; set; }

        public int fkUser { get; set; }

        public int fkTask { get; set; }

        public bool active { get; set; }

        public virtual Task Tasks { get; set; }

        public virtual User Users { get; set; }
    }
}
