using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Jobs.Descriptors
{
    public enum JobInputType
    {
        INT, 
        BOOL,
        STRING
    }
    public class JobInputDescriptor
    {
        private static Dictionary<JobInputType, Type[]> _typeMappings = new Dictionary<JobInputType, Type[]>
        {
            { JobInputType.INT, new Type[]{typeof(int)} },
            { JobInputType.BOOL, new Type[]{typeof(bool)} },
            { JobInputType.STRING, new Type[]{typeof(string)} }
        };

        public string Name { get; set; }
        public JobInputType Type { get; set; }
        public string[] TypeHas { get; set; }

        public bool InstanceMatchType(object type)
        {
            var acceptableTypes = _typeMappings[Type];
            return (acceptableTypes.Any(t => t.IsAssignableFrom(type.GetType()))) ;
        }
    }
}
