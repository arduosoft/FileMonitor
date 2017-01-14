using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Arduosoft.FileMonitor.Core;
using System.IO;

namespace Arduosoft.FileMonitor.Plugins
{
    public class Move : Core.FileProcessor
    {
        public override string ActionName
        {
            get
            {
                return "Move";
            }
        }

        public override void Process(EventContext context)
        {
            if (!context.Arguments.ContainsKey("destination")) throw new Exception("Move action requires destination field");

            string destination = context.Arguments["destination"];
            destination = destination.Replace("{filename}", Path.GetFileName(context.File.FilePath));
            destination = destination.Replace("{sourceDir}", Path.GetDirectoryName(context.File.FilePath));
            destination = destination.Replace("{sourceExt}", Path.GetExtension(context.File.FilePath));
            destination = destination.Replace("{dt}", DateTime.Now.ToString("yyyy-MM-dd-HHmmSS"));
            File.Move(context.File.FilePath, destination);
        }
    }
}
