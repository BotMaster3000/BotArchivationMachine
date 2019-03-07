using System;

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
