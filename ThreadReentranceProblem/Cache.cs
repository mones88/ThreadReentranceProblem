using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadReentranceProblem
{
    public class Cache<T>
    {
        private readonly Func<Task<T>> asyncFunc;
        private T value;

        public Task<T> Value
        {
            get
            {
                if (value == null || value.Equals(default(T)))
                {
                    Console.WriteLine("NOT CACHED");
                    /*value = asyncFunc().Result;
                    return Task.FromResult(value);*/
                    var task = asyncFunc();
                    task.ConfigureAwait(false);
                    value = task.Result;
                    return Task.FromResult(value);
                }
                else
                {
                    Console.WriteLine("CACHED");
                    return Task.FromResult(value);
                }
            }
        }

        public Cache(Func<Task<T>> asyncFunc)
        {
            this.asyncFunc = asyncFunc;
        }
    }
}
