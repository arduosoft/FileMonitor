using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Core
{
    public class FileStatus
    {
        public long Size { get; set; }
        public DateTime LastWrite { get; set; }
        public DateTime CreateDate { get; set; }
        public System.IO.FileInfo FileInfo { get; set; }
        public System.IO.FileInfo Info { get; internal set; }
    }
}
