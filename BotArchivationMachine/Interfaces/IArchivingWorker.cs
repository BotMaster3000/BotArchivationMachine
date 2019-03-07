using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotArchivationMachine.Interfaces
{
    public interface IArchivingWorker
    {
        void ArchivateDirectory(string path);
    }
}
