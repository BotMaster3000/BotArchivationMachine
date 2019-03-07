using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BotArchivationMachine.Interfaces;

namespace BotArchivationMachine.ViewModels
{
    public class ArchivationViewModel : IArchivationViewModel
    {
        public List<IArchiveModel> ArchiveModelList { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IArchiveManager ArchivationManager { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IDatabaseManager DatabaseManaget { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
