using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotArchivationMachine.Interfaces;

namespace BotArchivationMachine.Models
{
    public class ArchiveModel : IArchiveModel
    {
        public int ID { get; set; }
        public string Path { get; set; } = "";
        public DateTime? LastArchivingDate { get; set; }
        public int ArchivingIntervalInHours { get; set; }
    }
}
