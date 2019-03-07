using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotArchivationMachine.Interfaces
{
    public interface IDatabaseManager
    {
        void AddEnty(IArchiveModel archive);
        void RemoveEntry(IArchiveModel archive);
        List<IArchiveModel> GetAllEntries();
    }
}
