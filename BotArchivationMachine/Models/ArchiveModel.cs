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
        public int ID { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Path { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public DateTime LastArchivingDate { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public int ArchivingIntervalInHours { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
