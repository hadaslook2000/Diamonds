//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MiYa.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Companies
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Companies()
        {
            this.Orders = new HashSet<Orders>();
        }
    
        public int CompanyId { get; set; }
        public string Company { get; set; }
        public int Classification { get; set; }
        public string ContactPerson { get; set; }
        public int Prefix { get; set; }
        public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public int Country { get; set; }
        public System.DateTime DateRegistration { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public short IsInterested { get; set; }
    
        public virtual Classifications Classifications { get; set; }
        public virtual Countries Countries { get; set; }
        public virtual Prefixes Prefixes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
    }
}