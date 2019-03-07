using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotArchivationMachine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotArchivationMachine.Database.Tests
{
    [TestClass]
    public class DatabaseManagerTests
    {
        [TestMethod]
        public void DatabaseManager_Constructor_Test()
        {
            DatabaseManager databaseManager = new DatabaseManager();
        }
    }
}