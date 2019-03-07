using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotArchivationMachine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotArchivationMachine.Interfaces;
using System.IO;

namespace BotArchivationMachine.Database.Tests
{
    [TestClass]
    public class DatabaseManagerTests
    {
        private void DisposeDataBase()
        {
            if (File.Exists(DatabaseManager.DATABASE_NAME))
            {
                File.Delete(DatabaseManager.DATABASE_NAME);
            }
        }

        [TestMethod]
        public void DatabaseManager_Constructor_Test()
        {
            try
            {
                DatabaseManager manager = new DatabaseManager();
            }
            finally
            {
                DisposeDataBase();
            }
        }

        [TestMethod]
        public void DatabaseManager_GetAllEntries_ShouldReturnNoEntries()
        {
            try
            {
                DatabaseManager manager = new DatabaseManager();
                List<IArchiveModel> modelList = manager.GetAllEntries();

                Assert.AreEqual(0, modelList.Count);
            }
            finally
            {
                DisposeDataBase();
            }
        }
    }
}