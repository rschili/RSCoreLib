using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RSCoreLib
    {
    public static class TaskProfiler
        {
        private const string PROFILE_MESSAGEFORMAT = "{0} executed in {1:0.000} seconds.";
        private const string PROFILE_EXCEPTIONFORMAT = "{0} threw an exception after {1:0.000} seconds.";
        internal async static Task<T> ProfileAsync<T> (Func<T> func, string title)
            {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
                {
                var result = await Task.Run(func);
                sw.Stop();
                Log.Information(PROFILE_MESSAGEFORMAT, title, sw.Elapsed.TotalSeconds);
                return result;
                }
            catch (Exception)
                {
                Log.Warning(PROFILE_EXCEPTIONFORMAT, title, sw.Elapsed.TotalSeconds);
                throw;
                }
            }

        internal async static Task ProfileAsync (Action func, string title)
            {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            try
                {
                await Task.Run(func);
                sw.Stop();
                Log.Information(PROFILE_MESSAGEFORMAT, title, sw.Elapsed.TotalSeconds);
                }
            catch (Exception)
                {
                Log.Warning(PROFILE_EXCEPTIONFORMAT, title, sw.Elapsed.TotalSeconds);
                throw;
                }
            }
        }
    }
