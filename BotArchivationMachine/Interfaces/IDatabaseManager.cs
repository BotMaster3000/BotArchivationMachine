using System.Collections.Generic;

namespace BotArchivationMachine.Interfaces
{
    public interface IDatabaseManager
    {
        void AddEnty(IArchiveModel archive);
        void RemoveEntry(IArchiveModel archive);
        List<IArchiveModel> GetAllEntries();
    }
}
