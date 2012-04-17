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
using System.Reactive.Linq;
using System.Reactive;

namespace Silverlight_Rx_POC
{
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void btnDoIt_Click(object sender, RoutedEventArgs e)
        {
            var ec = new CrazyEventClass();

            var myevent = Observable.FromEvent<CrazyEventClass.MyEventHandler, EventArgs>(h => ec.MyEvent += h, h => ec.MyEvent -= h);
            //var sonofmyevent = Observable.FromEvent<CrazyEventClass.SonOfMyEventHandler>(h => ec.SonOfMyEvent += h, h => ec.SonOfMyEvent -= h);
            //var myeventvskingkong = Observable.FromEvent<CrazyEventClass.MyEventvsKingKongHandler>(h => ec.MyEventVSKingKong += h, h => ec.MyEventVSKingKong -= h);
            //var myeventvsmothra = Observable.FromEvent<CrazyEventClass.MyEventvsMothraHandler>(h => ec.MyEventVSMothra += h, h => ec.MyEventVSMothra -= h);

            //var merged = Observable.Merge(
            //    myevent.Select(_ => Unit.Default),
            //    sonofmyevent.Select(_ => Unit.Default),
            //    myeventvskingkong.Select(_ => Unit.Default),
            //    myeventvsmothra.Select(_ => Unit.Default)
            //    );
            //merged.Subscribe(_ => { MessageBox.Show("DidIt"); });

            myevent.Subscribe(_ => MessageBox.Show("Did it"));
        }

        private void DidIt()
        {
            MessageBox.Show("Did it");
        }
    }
}
