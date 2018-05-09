using Hearthstone_Deck_Tracker;
using HearthstoneHotkeys.IO;
using System.Drawing;

namespace HearthstoneHotkeys
{
    public struct GamePoint : ITransformable
    {
        public double X;

        public double Y;

        public GamePoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        public Point Transform(Rectangle rectangle)
        {
            var ratio = (4.0 / 3.0) / ((double)rectangle.Width / rectangle.Height);
            var x = (int)Helper.GetScaledXPos(X, rectangle.Width, ratio);
            var y = (int)(Y * rectangle.Height);
            return new Point(x, y);
        }
    }
}
