﻿using DatabaseCookingCoolR6.Data.Configurations;
using DataBasePatient.Data.Enums;
using DataBasePatient.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DataBasePatient.Data
{
    public class AppDbContext : DbContext
    {
        private string connectionString;

        public AppDbContext()
        {
            this.SetUpConnectionString();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Patient> Patients { get; set; } = null!;
        public DbSet<Gender> Gender { get; set; } = null!;
        public DbSet<Given> Givens { get; set; } = null!;
        public DbSet<Active> Active { get; set; } = null!;

        private void SetUpConnectionString()
        {
            try
            {
                var dataJson = File.ReadAllText("appsettings.json");
                var configuration = JsonSerializer.Deserialize<ConfigurationProj>(dataJson);
                this.connectionString = configuration?.DockerConnectionString ?? throw new ArgumentNullException();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
