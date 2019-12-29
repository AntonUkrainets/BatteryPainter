using Android.Graphics;

namespace Painter
{
    public class DrawFigure
    {
        public static RectF Simple(float width, float height, float sliderValue)
        {
            var left = width / 4;
            var right = width / 4 * 3;

            var top = height / 4 * 3 - sliderValue;

            var bottom = height / 4 * 3;

            var rectF = new RectF(left, top, right, bottom);

            return rectF;
        }

        public static RectF Circle(float width, float height)
        {
            var left = width / 4;
            var right = width / 4 * 3;

            var top = height / 4;
            var bottom = height / 4 * 3;

            var rect = new RectF(left, top, right, bottom);

            return rect;
        }
    }
}