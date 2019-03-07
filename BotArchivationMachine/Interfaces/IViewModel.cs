using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotArchivationMachine.Interfaces
{
    public interface IViewModel
    {
        List<IArchiveModel> ArchiveModelList { get; set; }
        IArchiveManager ArchivationManager { get; set; }
        IDatabaseManager DatabaseManaget { get; set; }
    }
}
