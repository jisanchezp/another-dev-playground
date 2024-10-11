using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds
{
    internal class TaskPlayground
    {
        public TaskPlayground() { }
        
        public void CreatAndRunTasksImplicitly()
        {
            Parallel.Invoke(
                () => { ParallelWork(1, 1000); },
                () => { ParallelWork(2, 1300); },
                () => { ParallelWork(3, 1900); },
                () => { ParallelWork(4, 1200); },
                () => { ParallelWork(5, 1250); }
            );
        }

        private void ParallelWork(int id, int delay)
        {
            Task.Delay(delay).Wait();
            Console.WriteLine($"ParallelWork {id} has been completed");
        }
    }
}
