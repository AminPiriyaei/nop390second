
using Nop.Core;
using Nop.Data;
using Nop.Plugin.UnitOfPallet.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace Nop.Plugin.UnitOfPallet.Data
{
    public class UnitOfPalletObjectContext : DbContext, IDbContext
    {
        public UnitOfPalletObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        public virtual bool ProxyCreationEnabled
        {
            get
            {
                return this.Configuration.ProxyCreationEnabled;
            }
            set
            {
                this.Configuration.ProxyCreationEnabled = (value);
            }
        }

        public virtual bool AutoDetectChangesEnabled
        {
            get
            {
                return this.Configuration.AutoDetectChangesEnabled;
            }
            set
            {
                this.Configuration.AutoDetectChangesEnabled = (value);
            }
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UnitOfPalletProductStockMap());

            base.OnModelCreating(modelBuilder);
        }

        public string CreateDatabaseScript()
        {
            return ((IObjectContextAdapter)this).ObjectContext.CreateDatabaseScript();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : BaseEntity
        {
            return base.Set<TEntity>();
        }

        public void Install()
        {
            Database.SetInitializer<UnitOfPalletObjectContext>(null);

            this.Database.ExecuteSqlCommand(this.CreateDatabaseScript(), new object[0]);

            this.SaveChanges();
        }

        public void Uninstall()
        {
            //drop the table
            var tableName = this.GetTableName<UnitOfPalletProduct>();
            this.DropPluginTable(tableName);

            this.SaveChanges();
        }

        public IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters) where TEntity : BaseEntity, new()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public int ExecuteSqlCommand(string sql, bool doNotEnsureTransaction = false, int? timeout = null, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public void Detach(object entity)
        {
            if (entity == null)
                throw new ArgumentNullException("entity");

            ((IObjectContextAdapter)this).ObjectContext.Detach(entity);
        }
    }
}
