using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using SchemaTypist.Core.Config;
using SchemaTypist.Core.Utilities;

namespace SchemaTypist.MSBuild.CustomTasks
{
    internal static class ConfigConverter
    {
        public CodeGenConfig Convert(SchemaTypistGeneratorTask task)
        {
            CodeGenConfig config = new CodeGenConfig();
        }
    }
}
