using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OS_Project.Resources;
using System.Windows.Media;
using System.Device.Location;
using Microsoft.Phone.Maps.Controls;
using System.Windows.Threading;
using NExtra.Geo;

namespace OS_Project
{
    public partial class MainPage : PhoneApplicationPage
    {

        private GeoCoordinateWatcher _watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
        private MapPolyline _line;
        private DispatcherTimer _timer = new DispatcherTimer();
        private long _startTime;
        // Constructor
        public MainPage()
        {
            InitializeComponent();


            _line = new MapPolyline();
            _line.StrokeColor = Colors.Red;   //color travel
            _line.StrokeThickness = 6;  //ขนาดของเส้น
            Map.MapElements.Add(_line);

            _watcher.PositionChanged += Watcher_PositionChanged;

            _timer.Interval = TimeSpan.FromSeconds(1);
            _timer.Tick += Timer_Tick; //start time
        }



        private void MainMap_Loaded(object sender, RoutedEventArgs e)
        {
            if (NavigationService.BackStack.Count() == 1)
            {
                NavigationService.RemoveBackEntry();
            }
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            TimeSpan runTime = TimeSpan.FromMilliseconds(System.Environment.TickCount - _startTime);
            timeLabel.Text = runTime.ToString(@"hh\:mm\:ss");
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            if (_timer.IsEnabled)
            {
                //click stop 
                _watcher.Stop();
                _timer.Stop();
                StartButton.Content = "Start";
                borderBtn.Background = new SolidColorBrush(Color.FromArgb(55, 103, 251, 117));
            }
            else
            {
                //click Start
                _watcher.Start();
                _timer.Start();
                _startTime = System.Environment.TickCount;
                StartButton.Content = "Stop";
                borderBtn.Background = new SolidColorBrush(Color.FromArgb(60, 245, 82, 82));
                paceLabel.Text = "00:00";
                timeLabel.Text = "00:00:00";
                caloriesLabel.Text = "0";
                distanceLabel.Text = "0 km";
            }
        }

        private double _kilometres;
        private long _previousPositionChangeTick;

        private void Watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            var coord = new GeoCoordinate(e.Position.Location.Latitude, e.Position.Location.Longitude);

            if (_line.Path.Count > 0)
            {

                var previousPoint = _line.Path.Last();
                var distance = coord.GetDistanceTo(previousPoint);
                var millisPerKilometer = (1000.0 / distance) * (System.Environment.TickCount - _previousPositionChangeTick);
                _kilometres += distance / 1000.0;

                paceLabel.Text = TimeSpan.FromMilliseconds(millisPerKilometer).ToString(@"mm\:ss");
                distanceLabel.Text = string.Format("{0:f2} km", _kilometres);
                caloriesLabel.Text = string.Format("{0:f0}", _kilometres * 65);

                PositionHandler handler = new PositionHandler();
                var heading = handler.CalculateBearing(new Position(previousPoint), new Position(coord));
                Map.SetView(coord, Map.ZoomLevel, heading, MapAnimationKind.Parabolic);

                Map.CartographicMode = MapCartographicMode.Hybrid;
            }
            else
            {
                Map.Center = coord;
            }

            _line.Path.Add(coord);
            _previousPositionChangeTick = System.Environment.TickCount;

            //MessageBox.Show("Time : "+System.Environment.TickCount);
        }


    }
}