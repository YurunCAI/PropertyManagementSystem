﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PropertyManagementSystem.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PropertyManagementSystemEntities : DbContext
    {
        public PropertyManagementSystemEntities()
            : base("name=PropertyManagementSystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<w_admin> w_admin { get; set; }
        public virtual DbSet<w_property_information> w_property_information { get; set; }
        public virtual DbSet<w_system_params> w_system_params { get; set; }
    }
}