using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Threading;

namespace Silverlight_Wait_POC
{
    public partial class MainPage : UserControl
    {
        private ManualResetEvent mre = new ManualResetEvent(false);

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnGo_Click(object sender, RoutedEventArgs e)
        {
            //lstOut.Items.Add("\nStart 3 named threads that block on a ManualResetEvent:\n");

            //for (int i = 0; i <= 2; i++)
            //{
            //    Thread t = new Thread(ThreadProc);
            //    t.Name = "Thread_" + i;
            //    t.Start();
            //}

            //Thread.Sleep(500);
            //lstOut.Items.Add("\nWhen all three threads have started, press Enter to call Set()" +
            //                  "\nto release all the threads.\n");            

            lstOut.Items.Add("Starting a new thread that will wait one second then call set.");
            var t = new Thread(() => { Thread.Sleep(1000); mre.Set(); });
            t.Start();
            mre.WaitOne();
            lstOut.Items.Add("Set must have been called.");
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            mre.Set();
        }

        private void ThreadProc()
        {
            string name = Thread.CurrentThread.Name;

            Deployment.Current.Dispatcher.BeginInvoke(() => lstOut.Items.Add(name + " starts and calls mre.WaitOne()"));

            mre.WaitOne();

            Deployment.Current.Dispatcher.BeginInvoke(() => lstOut.Items.Add(name + " ends."));
        }
    }
}
