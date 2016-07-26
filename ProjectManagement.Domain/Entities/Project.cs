using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities
{
    public class Project
    {
        [Key]
        public int id { get; set; }
        public bool active { get; set; }
        public string name { get; set; }
        public DateTime createDate { get; set; }
        public int fkInitiator { get; set; }
    }
}
