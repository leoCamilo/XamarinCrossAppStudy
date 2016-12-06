using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Hardware;

namespace CrossAppStudy.Droid
{
    [Activity(Label = "Accelerometer")]
    public class Accelerometer : Activity, ISensorEventListener
    {
        static readonly object _syncLock = new object();
        SensorManager _sensorManager;
        TextView _sensorTextView;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.LayoutAccelerometer);
            _sensorManager = (SensorManager)GetSystemService(Context.SensorService);
            _sensorTextView = FindViewById<TextView>(Resource.Id.textViewAccelerometer);
        }

        protected override void OnResume()
        {
            base.OnResume();
            _sensorManager.RegisterListener(this, _sensorManager.GetDefaultSensor(SensorType.Accelerometer), SensorDelay.Ui);
        }

        protected override void OnPause()
        {
            base.OnPause();
            _sensorManager.UnregisterListener(this);
        }

        public void OnAccuracyChanged(Sensor sensor, SensorStatus accuracy)
        {
            // We don't want to do anything here.
        }

        public void OnSensorChanged(SensorEvent e)
        {
            lock (_syncLock)
            {
                _sensorTextView.Text = string.Format("x={0:f}, y={1:f}, y={2:f}", e.Values[0], e.Values[1], e.Values[2]);
            }
        }
    }
}