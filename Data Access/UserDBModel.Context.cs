﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data_Access
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HealthAndFitnessDBEntities : DbContext
    {
        public HealthAndFitnessDBEntities()
            : base("name=HealthAndFitnessDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<UserInfo> UserInfoes { get; set; }
        public virtual DbSet<AgeGrpWorkout> AgeGrpWorkouts { get; set; }
        public virtual DbSet<SymptomsOrDisease> SymptomsOrDiseases { get; set; }
        public virtual DbSet<UserSymptom> UserSymptoms { get; set; }
        public virtual DbSet<FoodItem> FoodItems { get; set; }
        public virtual DbSet<UserHealthInfo> UserHealthInfoes { get; set; }
    }
}
