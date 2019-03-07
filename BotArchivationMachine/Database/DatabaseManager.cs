using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotArchivationMachine.Interfaces;

namespace BotArchivationMachine.Database
{
    public class DatabaseManager : IDatabaseManager
    {
        public void AddEnty(IArchiveModel archive)
        {
            throw new NotImplementedException();
        }

        public List<IArchiveModel> GetAllEntries()
        {
            throw new NotImplementedException();
        }

        public void RemoveEntry(IArchiveModel archive)
        {
            throw new NotImplementedException();
        }
    }
}
