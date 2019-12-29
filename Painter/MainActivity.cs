using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Android.Content.PM;

using Xamarin.Essentials;

using System;
using Android.Views;
using Java.Interop;

namespace Painter
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private DrawView _drawView;

        private float _sliderValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            SetContentView(Resource.Layout.activity_main);
            
            _drawView = FindViewById<DrawView>(Resource.Id.PainterDrawView);

            FindViewById<Button>(Resource.Id.SimpleButton).Click += (sender, args) => RedrawFigure(FigureType.Simple);
            FindViewById<Button>(Resource.Id.CircleButton).Click += (sender, args) => RedrawFigure(FigureType.Circle);
            FindViewById<Button>(Resource.Id.BarButton).Click += (sender, args) => RedrawFigure(FigureType.Bar);

            FindViewById<SeekBar>(Resource.Id.FigureSlider).ProgressChanged += FigureSlider_ProgressChanged;
        }

        private void FigureSlider_ProgressChanged(object sender, SeekBar.ProgressChangedEventArgs e)
        {
            var figureSlider = FindViewById<SeekBar>(Resource.Id.FigureSlider);

            _drawView.SliderValue = figureSlider.Progress;
            _sliderValue = figureSlider.Progress;
            _drawView.Invalidate();
        }

        private void RedrawFigure(FigureType figureType)
        {
            _drawView.FigureType = figureType;
            _drawView.SliderValue = _sliderValue;
            _drawView.Invalidate();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        {
            Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);
            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}