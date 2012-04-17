using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Silverlight_Rx_POC
{
    public class CrazyEventClass
    {
        public delegate void MyEventHandler();
        private event MyEventHandler _myEventCompleted;
        public event MyEventHandler MyEvent
        {
            add { _myEventCompleted += value; }
            remove { _myEventCompleted -= value; }
        }

        public delegate void SonOfMyEventHandler(EventArgs e);
        private event SonOfMyEventHandler _sonOfMyEventCompleted;
        public event SonOfMyEventHandler SonOfMyEvent
        {
            add { _sonOfMyEventCompleted += value; }
            remove { _sonOfMyEventCompleted -= value; }
        }

        public delegate void MyEventvsKingKongHandler();
        private event MyEventvsKingKongHandler _myEventvsKingKongCompleted;
        public event MyEventvsKingKongHandler MyEventVSKingKong
        {
            add { _myEventvsKingKongCompleted += value; }
            remove { _myEventvsKingKongCompleted -= value; }
        }

        public delegate void MyEventvsMothraHandler();
        private event MyEventvsMothraHandler _myEventvsMothraCompleted;
        public event MyEventvsMothraHandler MyEventVSMothra
        {
            add { _myEventvsMothraCompleted += value; }
            remove { _myEventvsMothraCompleted -= value; }
        }
    }
}
