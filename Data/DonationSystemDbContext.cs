using Microsoft.EntityFrameworkCore;
using Blood_Donation_System.Models.Entities.BloodBank;
using Blood_Donation_System.Models.Entities.BloodBank.Enums;

namespace Blood_Donation_System.Data
{
    public class DonationSystemDbContext : DbContext
    {
        public DonationSystemDbContext(DbContextOptions<DonationSystemDbContext> options) : base(options)
        {
        }

        

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            base.OnModelCreating(modelbuilder); 

            modelbuilder.Entity<BloodRequest>().Property(e => e.requestType).HasConversion(v => v.ToString(), v => (requestType)Enum.Parse(typeof(requestType), v));
            modelbuilder.Entity<Donation>().Property(e => e.bloodGroup).HasConversion(v => v.ToString(), v => (Group)Enum.Parse(typeof(Group), v));
            modelbuilder.Entity<BloodRequest>().Property(e => e.bloodType).HasConversion(v => v.ToString(), v => (Group)Enum.Parse(typeof(Group), v));
            modelbuilder.Entity<Donor>().Property(e => e.bloodType).HasConversion(v => v.ToString(), v => (Group)Enum.Parse(typeof(Group), v));
            modelbuilder.Entity<Supply>().Property(e => e.bloodType).HasConversion(v => v.ToString(), v => (Group)Enum.Parse(typeof(Group), v));
            modelbuilder.Entity<Supply>().Property(e => e.Type).HasConversion(v => v.ToString(), v => (supplyType)Enum.Parse(typeof(supplyType), v));

        }
        public DbSet<BloodBank> BloodBanks { get; set; }
        public DbSet<BloodRequest> BloodRequests { get; set; }
        public DbSet<Donation> Donations { get; set; }
        public DbSet<Supply> Supplies { get; set; }
        public DbSet<Donor> Donors { get; set; }
        
    }
}
