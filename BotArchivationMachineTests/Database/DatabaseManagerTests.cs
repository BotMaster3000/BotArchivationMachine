﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using BotArchivationMachine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotArchivationMachine.Interfaces;
using System.IO;
using BotArchivationMachine.Models;

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

        [TestMethod]
        public void DatabaseManager_AddEntry_ShouldWork()
        {
            try
            {
                ArchiveModel model = new ArchiveModel()
                {
                    ID = new Random().Next(1000000),
                    Path = "Bla",
                    LastArchivingDate = DateTime.Now.AddDays(-1),
                    ArchivingIntervalInHours = 41,
                };
                DatabaseManager manager = new DatabaseManager();
                manager.AddEnty(model);

                List<IArchiveModel> returnedModelList = manager.GetAllEntries();
                Assert.AreEqual(1, returnedModelList.Count);

                IArchiveModel returnedModel = returnedModelList[0];

                Assert.AreEqual(model.ID, returnedModel.ID);
                Assert.AreEqual(model.Path, returnedModel.Path);
                Assert.AreEqual(model.LastArchivingDate?.ToString("yyyy-MM-dd HH:mm:ss"), returnedModel.LastArchivingDate?.ToString("yyyy-MM-dd HH:mm:ss"));
                Assert.AreEqual(model.ArchivingIntervalInHours, returnedModel.ArchivingIntervalInHours);
            }
            finally
            {
                DisposeDataBase();
            }
        }
    }
}