using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Jobs.Descriptors
{
    public class SubJobDescriptor
    {
        public string JobName { get; set; }
        public Dictionary<string, string> Inputs { get; set; }
    }
}
