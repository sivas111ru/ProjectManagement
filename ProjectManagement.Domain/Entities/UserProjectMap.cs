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
    
    public partial class UserProjectMap
    {
        public int id { get; set; }
        public bool active { get; set; }
        public int fkUser { get; set; }
        public int fkProject { get; set; }
    
        public virtual Project Project { get; set; }
        public virtual User User { get; set; }
    }
}
