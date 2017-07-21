using Assets.Core.Jobs.Descriptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Jobs
{
    public class JobInstance
    {
        public JobDescriptor Descriptor { get; private set; }
        public Dictionary<string, object> Inputs { get; set; }

        public JobInstance(JobDescriptor descriptor, Dictionary<string, object> inputs)
        {
            Descriptor = descriptor;
            Inputs = inputs;

            //Descriptor.Conditions.Select(cond =>
            //{
            //    cond.Expression 
            //    return 4;
            //});

            if (descriptor.HasValidInputs(inputs) == false)
            {
                throw new InvalidOperationException("Invalid inputs to job " + descriptor.Name);
            }
        }

        public bool IsJobComplete()
        {
            return false;
        }
    }
}
