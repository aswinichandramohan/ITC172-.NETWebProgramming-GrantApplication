//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace community_assis_2017.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeePosition
    {
        public int PositionKey { get; set; }
        public int EmployeeKey { get; set; }
        public Nullable<System.DateTime> EmployeePositionDateAdded { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Position Position { get; set; }
    }
}
