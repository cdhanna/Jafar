using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Core.Jobs
{
    public interface IJob
    {
        /*
         * A job has specific tasks, and constraints 
         * Jobs are heirachical in nature. 
         * "Build Library" is decomposed into "carve out space for library", "build walls" 
         * 
         * Workers do jobs
         * Workers meet the constraints to some level of efficiency. A worker has the information about how long a job will take. 
         */
    }
}
