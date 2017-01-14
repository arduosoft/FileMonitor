using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Core
{
    public class EventContext
    {
        public FileChangeEvent Event { get; private set; }
        public FileInfo File { get; private set; }
        public Dictionary<string,string> Arguments { get; private set; }

        public EventContext(FileChangeEvent eventToHandle, FileInfo file,  Dictionary<string,string> Arguments)
        {
            this.Event = eventToHandle;
            this.File = file;
            this.Arguments = Arguments;
        }
    }
}
