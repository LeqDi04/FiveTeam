//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FiveTeam.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int ID { get; set; }
        public Nullable<int> Catalogld { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string Picture { get; set; }
        public Nullable<double> UnitPrice { get; set; }
    
        public virtual Catalog Catalog { get; set; }
    }
}