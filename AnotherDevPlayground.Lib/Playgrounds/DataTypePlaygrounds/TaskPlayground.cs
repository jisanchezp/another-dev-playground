using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnotherDevPlayground.Lib.Playgrounds.DataTypePlaygrounds
{
    internal class TaskPlayground
    {
        internal TaskPlayground() {
            Thread.CurrentThread.Name = "Main";

            //CreateAndRunTasksImplicitly();
            //CreateAndRunTasksExplicitlyLesserControl();
            AsyncState_CreateTaskFactory();
        }

        class CustomData
        {
            public long CreationTime { get; set; }
            public int Name { get; set; }
            public int ThreadNum { get; set; }
        }

        void AsyncState_CreateTaskFactory()
        {
            Task[] taskArray = new Task[10];
            for (int i = 0; i < taskArray.Length; i++)
            {
                taskArray[i] = Task.Factory.StartNew((Object obj) =>
                {
                    CustomData data = obj as CustomData;
                    if (data == null) return;

                    data.ThreadNum = Thread.CurrentThread.ManagedThreadId;
                },
                new CustomData()
                {
                    Name = i,
                    CreationTime = DateTime.UtcNow.Ticks
                });
            }
            Task.WaitAll(taskArray); ;
            foreach (Task task in taskArray)
            {
                var data = task.AsyncState as CustomData;
                if (data != null)
                    Console.WriteLine("Task #{0} created at {1}, ran on thread #{2}",
                        data.Name, data.CreationTime, data.ThreadNum);
            }
        }

        

        void CreateAndRunTasksExplicitlyLesserControl()
        {
            /* 
             
            The Run methods are the preferred way 
            to create and start tasks when more 
            control over the creation and scheduling
            isn't needed.

             */

            Task taskA = Task.Run(() => Console.WriteLine("Hello from taskA."));

            Console.WriteLine("Hello from thread '{0}'",
                                    Thread.CurrentThread.Name);

            taskA.Wait();
        }

        void CreateAndRunTasksExplicitlyGreaterControl()
        {
            /* 
            
            When you need greater control over
            task execution or return a value
            from the task, you must work with Task 
            objected more explicitly.

            */

            Task taskA = new Task(() => Console.WriteLine("Hello from task A!"));
            taskA.Start();

            Console.WriteLine("Hello from thread '{0}'",
                                    Thread.CurrentThread.Name);

            taskA.Wait();
        }

        void CreateAndRunTasksImplicitly()
        {
            Parallel.Invoke(
                () => { ParallelWork(1, 1000); },
                () => { ParallelWork(2, 1300); },
                () => { ParallelWork(3, 1900); },
                () => { ParallelWork(4, 1200); },
                () => { ParallelWork(5, 1250); }
            );
        }

        void ParallelWork(int id, int delay)
        {
            Task.Delay(delay).Wait();
            Console.WriteLine($"ParallelWork {id} has been completed");
        }
    }
}
