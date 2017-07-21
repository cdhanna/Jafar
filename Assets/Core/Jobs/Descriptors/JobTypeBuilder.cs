using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Assets.Core.Jobs.Descriptors
{
   
    public class JobTypeBuilder
    {
        private string _name, _desc;
        private List<JobInputDescriptor> _inputs;
        private List<SubJobDescriptor> _subjobs;
        private List<JobConditionDescriptor> _conditions;

        public JobTypeBuilder()
        {
            _name = "Unnamed";
            _desc = "No Description";
            _inputs = new List<JobInputDescriptor>();
            _subjobs = new List<SubJobDescriptor>();
            _conditions = new List<JobConditionDescriptor>();
        }

        public JobTypeBuilder SetName(string name)
        {
            _name = name;
            return this;
        }

        public JobTypeBuilder SetDesc(string desc)
        {
            _desc = desc;
            return this;
        }

        public JobTypeBuilder AddInput(string name, JobInputType type, string[] typeHas=null)
        {
            _inputs.Add(new JobInputDescriptor()
            {
                Name = name,
                Type = type,
                TypeHas = typeHas == null ? new string[] { } : typeHas
            });
            return this; 
        }

        public JobTypeBuilder AddSubJob(string name, Dictionary<string, string> arguments=null)
        {
            _subjobs.Add(new SubJobDescriptor()
            {
                JobName = name,
                Inputs = arguments
            });
            return this;
        }

        public JobTypeBuilder AddCondition(string name, string expression)
        {
            _conditions.Add(new JobConditionDescriptor()
            {
                Name = name,
                Expression = expression
            });
            return this;
        }

        public JobDescriptor Build()
        {
            return new JobDescriptor()
            {
                Name = _name,
                Description = _desc,
                Conditions = _conditions.ToArray(),
                Inputs = _inputs.ToArray(),
                SubJobs = _subjobs.ToArray()
            };
        }
    }
}
