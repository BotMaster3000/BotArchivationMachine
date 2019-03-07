using System.Collections.Generic;

namespace BotArchivationMachine.Interfaces
{
    public interface IArchivationViewModel
    {
        List<IArchiveModel> ArchiveModelList { get; set; }
        IArchiveManager ArchivationManager { get; set; }
        IDatabaseManager DatabaseManaget { get; set; }
    }
}
