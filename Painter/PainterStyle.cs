using Android.Graphics;

namespace Painter
{
    public class PainterStyle
    {
        public static Paint CreateTextPaintStyle()
        {
            var textStyle = new Paint
            {
                TextSize = 100,
                Color = Color.Red,
                TextAlign = Paint.Align.Center
            };

            return textStyle;
        }

        public static Paint CreateFigurePaintStyle(Paint.Style style)
        {
            var figureStyle = new Paint
            {
                Color = Color.Red,
                StrokeWidth = 30
            };

            figureStyle.SetStyle(style);

            return figureStyle;
        }
    }
}