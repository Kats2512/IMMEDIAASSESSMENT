﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IMMEDIAEntities : DbContext
    {
        public IMMEDIAEntities()
            : base("name=IMMEDIAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<FourSquareVenueMetaData> FourSquareVenueMetaDatas { get; set; }
        public virtual DbSet<FourSquareVenueRecommendationsMetaData> FourSquareVenueRecommendationsMetaDatas { get; set; }
        public virtual DbSet<FourSquarePhotoMetaData> FourSquarePhotoMetaDatas { get; set; }
    }
}