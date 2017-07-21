using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Jobs.Descriptors
{
    public class JobDescriptor
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public JobInputDescriptor[] Inputs { get; set; }
        public SubJobDescriptor[] SubJobs { get; set; }
        public JobConditionDescriptor[] Conditions { get; set; }


        public bool HasValidInputs(Dictionary<string, object> inputs)
        {
            for (int i = 0; i < Inputs.Length; i++)
            {
                var input = Inputs[i];
                object givenInput = null; 
                if (inputs.TryGetValue(input.Name, out givenInput) == false)
                {
                    return false;
                }

                if (input.InstanceMatchType(givenInput) == false)
                {
                    return false;
                }
            }
            return true;
        }

    }
}
