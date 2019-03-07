using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotArchivationMachine.Interfaces
{
    public interface IArchiveModel
    {
        int ID { get; set; }
        string Path { get; set; }
        DateTime? LastArchivingDate { get; set; }
        int ArchivingIntervalInHours { get; set; }
    }
}
