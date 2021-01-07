using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace TableTopCatalogDemoApp.Data.Design.DataSeed
{
    class DataSeedOrchestrator
    {
        private readonly TableTopDataContext _context;
        private readonly Lazy<List<IDataSeedPack>> _dataSeedPacks = new Lazy<List<IDataSeedPack>>(() =>
        {
            var packs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(x => 
                    x.IsClass && 
                    x.GetInterfaces().Contains(typeof(IDataSeedPack)))
                .Select(x => (IDataSeedPack)Activator.CreateInstance(x));

            return new List<IDataSeedPack>(packs);
        });

        public DataSeedOrchestrator(TableTopDataContext context, List<IDataSeedPack> dataSeedPacks = null)
        {
            _context = context;

            if (dataSeedPacks != null)
            {
                _dataSeedPacks = new Lazy<List<IDataSeedPack>>(dataSeedPacks);
            }
        }

        public void PrepareDatabase()
        {
            _context.Database.ExecuteSqlRaw(DataSeedOrchestratorSql.CreateDataSeedTable);
        }

        public void ApplyAll()
        {
            var seedId = new SqlParameter("@ID", SqlDbType.NVarChar, 150);

            foreach (var dataSeedPack in _dataSeedPacks.Value)
            {
                seedId.Value = dataSeedPack.GetUniqueId();

                if (_context.Database.ExecuteSqlRaw(DataSeedOrchestratorSql.InsertDataSeedInfo, seedId) == 1)
                {
                    dataSeedPack.Apply(_context);
                    _context.SaveChanges();
                }
            }
        }
    }

    #region SQL

    static class DataSeedOrchestratorSql
    {
        internal const string CreateDataSeedTable = @"
            IF OBJECT_ID(N'[__DataSeedsHistory]') IS NULL
            BEGIN
	            CREATE TABLE [dbo].[__DataSeedsHistory](
		            [DataSeedId] [nvarchar](150) NOT NULL,
		            [AppliedOn] [smalldatetime] NOT NULL DEFAULT (getdate()),
		            CONSTRAINT [PK___DataSeedsHistory] PRIMARY KEY ([DataSeedId]))
            END;
        ";

        internal const string InsertDataSeedInfo = @"
            IF NOT EXISTS (SELECT * FROM [dbo].[__DataSeedsHistory] WHERE [DataSeedId] = @ID)
            BEGIN
	            INSERT INTO [dbo].[__DataSeedsHistory] ([DataSeedId]) VALUES (@ID)
            END
        ";
    }

    #endregion
}
