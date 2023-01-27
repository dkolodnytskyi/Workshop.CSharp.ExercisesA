﻿using HospitalApp.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HospitalApp.Data
{
    public class AdministratorContext : IdentityDbContext
    {
        public DbSet<Doctor> doctors { get; set; }
        public DbSet<Patient> patients { get; set; }
        public DbSet<Visit> visits { get; set; }



        public AdministratorContext(DbContextOptions<AdministratorContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }

}