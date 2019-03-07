using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotArchivationMachine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotArchivationMachine.Models.Tests
{
    [TestClass]
    public class ArchiveModelTests
    {
        [TestMethod]
        public void ArchiveModel_ConstructorTest()
        {
            ArchiveModel model = new ArchiveModel();
        }

        [TestMethod]
        public void ArchiveModel_ID_Property_Test()
        {
            int expectedID = 0;
            ArchiveModel model = new ArchiveModel();
            Assert.AreEqual(expectedID, model.ID);

            expectedID = 4221;
            model.ID = expectedID;
            Assert.AreEqual(expectedID, model.ID);
        }

        [TestMethod]
        public void ArchiveModel_Path_Property_Test()
        {
            string expectedPath = "";
            ArchiveModel model = new ArchiveModel();
            Assert.AreEqual(expectedPath, model.Path);

            expectedPath = "TestPath";
            model.Path = expectedPath;
            Assert.AreEqual(expectedPath, model.Path);
        }

        [TestMethod]
        public void ArchiveModel_LastArchivingDate_Property_Test()
        {
            DateTime? expectedDateTime = null;
            ArchiveModel model = new ArchiveModel();
            Assert.AreEqual(expectedDateTime, model.LastArchivingDate);

            expectedDateTime = DateTime.Now;
            model.LastArchivingDate = expectedDateTime;
            Assert.AreEqual(expectedDateTime, model.LastArchivingDate);
        }

        [TestMethod]
        public void ArchvieModel_ArchivingIntervalInHours_Property_Test()
        {
            int expectedInterval = 0;
            ArchiveModel model = new ArchiveModel();
            Assert.AreEqual(expectedInterval, model.ArchivingIntervalInHours);

            expectedInterval = 42;
            model.ArchivingIntervalInHours = expectedInterval;
            Assert.AreEqual(expectedInterval, model.ArchivingIntervalInHours);
        }
    }
}