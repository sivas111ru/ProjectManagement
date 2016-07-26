using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities
{
    public class Task
    {
        [Key]
        public int id { get; set; }
        public int fkProject { get; set; }
        public bool active { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public byte priority { get; set; }
        public int status { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

    }
}
