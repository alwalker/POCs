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
        CrazyEventClass ec = new CrazyEventClass();

        public MainPage()
        {
            InitializeComponent();
        }

        private void btnSubscribe_Click(object sender, RoutedEventArgs e)
        {
            var myevent = Observable.FromEventPattern<CrazyEventClass.MyEventHandler, EventArgs>(h => ec.MyEvent += h, h => ec.MyEvent -= h);
            var sonofmyevent = Observable.FromEventPattern<CrazyEventClass.SonOfMyEventHandler, EventArgs>(h => ec.SonOfMyEvent += h, h => ec.SonOfMyEvent -= h);
            var myeventvskingkong = Observable.FromEventPattern<CrazyEventClass.MyEventvsKingKongHandler, EventArgs>(h => ec.MyEventVSKingKong += h, h => ec.MyEventVSKingKong -= h);
            var myeventvsmothra = Observable.FromEventPattern<CrazyEventClass.MyEventvsMothraHandler, EventArgs>(h => ec.MyEventVSMothra += h, h => ec.MyEventVSMothra -= h);

            var merged = Observable.Merge(
                myevent.Select(_ => Unit.Default),
                sonofmyevent.Select(_ => Unit.Default),
                myeventvskingkong.Select(_ => Unit.Default),
                myeventvsmothra.Select(_ => Unit.Default)
                );
            merged.Subscribe(_ => DidIt());

            //myevent.Subscribe(_ => DidIt(null));
        }

        private void DidIt()
        {
            MessageBox.Show("Did it");
        }

        private void btnFireEvents_Click(object sender, RoutedEventArgs e)
        {
            ec.FireMeSomeEvents();
        }
    }
}
