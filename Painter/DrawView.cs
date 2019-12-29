using Android.Content;
using Android.Graphics;
using Android.Util;
using Android.Views;

namespace Painter
{
    public class DrawView : View
    {
        private float _sliderValue;
        private float _progressPercent;

        public FigureType FigureType { get; set; }

        public float SliderValue
        {
            get => _sliderValue;
            set
            {
                _progressPercent = value;

                if (FigureType == FigureType.Circle)
                    _sliderValue = value * 3.6f;
                else
                    _sliderValue = value;
            }
        }

        public DrawView(Context context, IAttributeSet attrs) : base(context, attrs) { }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            Paint figureStyle;

            switch (FigureType)
            {
                case FigureType.Simple:
                    figureStyle = PainterStyle.CreateFigurePaintStyle(Paint.Style.FillAndStroke);
                    DrawSimple(canvas, figureStyle);
                    DrawText(canvas, FigureType.Simple);
                    break;
                case FigureType.Circle:
                    figureStyle = PainterStyle.CreateFigurePaintStyle(Paint.Style.Stroke);
                    DrawCircle(canvas, figureStyle);
                    DrawText(canvas, FigureType.Circle);
                    break;
                case FigureType.Bar:
                    figureStyle = PainterStyle.CreateFigurePaintStyle(Paint.Style.Fill);
                    DrawBar(canvas, figureStyle);
                    DrawText(canvas, FigureType.Bar);
                    break;
            }
        }

        private void DrawSimple(Canvas canvas, Paint figurePaint)
        {
            _sliderValue *= canvas.Height / 2 / 100;

            var rect = Painter.Draw.Simple(canvas.Width, canvas.Height, _sliderValue);
            canvas.DrawRect(rect, figurePaint);
        }

        private void DrawCircle(Canvas canvas, Paint figurePaint)
        {
            var oval = Painter.Draw.Circle(canvas.Width, canvas.Height);
            canvas.DrawArc(oval, startAngle: 270, sweepAngle: _sliderValue, useCenter: false, figurePaint);
        }

        private void DrawBar(Canvas canvas, Paint figurePaint)
        {
            var rectf = Painter.Draw.Bar(canvas.Width, canvas.Height);

            var roundFigure = 20;
            for (int i = 0; i < _sliderValue; i += 10)
            {
                canvas.DrawRoundRect(rectf, roundFigure, roundFigure, figurePaint);

                var percent = canvas.Height / 100 * 7;
                rectf.Offset(dx: 0, dy: -percent);
            }
        }

        private void DrawText(Canvas canvas, FigureType figureType)
        {
            var textHeight = Painter.Draw.GetTextHeight(figureType, canvas.Height, _sliderValue);
            var textStyle = PainterStyle.CreateTextPaintStyle();

            canvas.DrawText($"{_progressPercent}%", canvas.Width / 2, textHeight, textStyle);
        }
    }
}