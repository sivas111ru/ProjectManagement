using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagement.Domain.Entities
{
    public class User
    {
        [Key]  // force primary key, default for EF is "Id"
        public int id { get; set; }
        public string name { get; set; }
        public string role { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public bool notification { get; set; }

    }
}
