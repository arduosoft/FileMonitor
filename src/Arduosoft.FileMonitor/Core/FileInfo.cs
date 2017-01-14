using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Core
{
    public class FileInfo
    {
        public string FilePath { get; set; }
        public string Name { get; set; }
        public FileStatus ActualStatus { get { return History.FirstOrDefault(); } }

        public FileHistory History { get; set; }

        public FileInfo()
        {
            History = new FileHistory();
        }
        
    }
}
