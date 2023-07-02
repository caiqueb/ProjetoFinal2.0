using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;

namespace ProjetoFinal2._0.Models
{
    public class ProjetoContext : DbContext
    {
        public ProjetoContext() : base("DefaultConnection")
        {

        }

        //DESABILITAR CASCATAS

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Departaments> Departaments { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.City> Cities { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Company> Companies { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.User> Users { get; set; }
        public IEnumerable<object> TaxPaers { get; internal set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Category> Categories { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Tax> Taxes { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Product> Products { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.WareHouse> WareHouses { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Inventory> Inventories { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Customer> Customers { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Orders> Orders { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.OrderDetails> OrderDetail { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.OrderDetailTmp> OrderDetailTmp { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.CompanyCustomer> CompanyCustomers { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.CompanyProvider> CompanyProviders { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Purchase> Purchases { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.PurchaseDetails> PurchaseDetails { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.PurchaseDetailTmp> PurchaseDetailTmps { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.State> States { get; set; }

        public System.Data.Entity.DbSet<ProjetoFinal2._0.Models.Provider> Providers { get; set; }
    }
}