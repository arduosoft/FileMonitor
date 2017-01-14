using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arduosoft.FileMonitor.Core
{
    public abstract class FileProcessor
    {
        public abstract string ActionName{get;}

        public abstract void Process(EventContext context);
    }
}
