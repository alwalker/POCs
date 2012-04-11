using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadingTimerPOC
{
    class Program
    {
        static void Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            var thingy = Thingy.GetThingy();
            while (true) { }
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Console.WriteLine("BARF");
            System.Threading.Thread.Sleep(5000);
            Main(null);
        }
    }

    public class Thingy
    {
        private static Timer _timer;
        private static int _callCount = 0;
        private static Thingy _instance = null;

        public static Thingy GetThingy()
        {
            if (_instance == null)
            {
                _instance = new Thingy();
            }

            return _instance;
        }

        private Thingy()
        {
            _timer = new Timer((result) =>
                            {
                                Console.WriteLine("call count: " + _callCount);
                                if (++_callCount == 3)
                                {
                                    throw new ApplicationException("YOU SUCK");
                                }
                            }, null, 0, 1000);
        }
    }
}
