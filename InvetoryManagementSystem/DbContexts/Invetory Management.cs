using Microsoft.EntityFrameworkCore;

namespace InvetoryManagementSystem.DbContexts
{
    public class Invetory_Management :DbContext
    {
        public Invetory_Management() { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database= Inventory_Management_System; Trusted_Connection =true  ;TrustServerCertificate=true");
        }







    }
}
