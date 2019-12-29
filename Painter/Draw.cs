using Android.Graphics;

namespace Painter
{
    public class Draw
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
            var left = width / 6;
            var right = width / 6 * 5;

            var top = height / 4;
            var bottom = height / 4 * 3;

            var rect = new RectF(left, top, right, bottom);

            return rect;
        }

        public static RectF Bar(int width, int height)
        {
            var left = width / 3;
            var right = width / 4 * 3;

            var top = height * 0.95f;
            var bottom = height;

            var rectf = new RectF(left, top, right, bottom);

            return rectf;
        }

        public static float GetTextHeight(FigureType figureType, float canvasHeight, float sliderValue)
        {
            float height = 0;

            switch (figureType)
            {
                case FigureType.Simple:
                    height = canvasHeight / 4 * 3 - sliderValue - 20;
                    break;
                case FigureType.Circle:
                    height = canvasHeight / 2 + 20;
                    break;
                case FigureType.Bar:
                    height = canvasHeight * 0.95f - sliderValue * 13.5f;
                    break;
            }

            return height;
        }
    }
}