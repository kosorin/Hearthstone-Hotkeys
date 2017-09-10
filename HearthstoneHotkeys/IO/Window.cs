﻿using Hearthstone_Deck_Tracker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HearthstoneHotkeys.IO
{
    public static class Window
    {
        #region WinAPI

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr window, out ScreenPoint point);

        [DllImport("user32.dll")]
        static extern bool GetClientRect(IntPtr window, out Rectangle rectangle);

        #endregion

        public static ScreenPoint GamePositionToScreenPosition(GamePoint gamePosition)
        {
            var window = User32.GetHearthstoneWindow();
            var point = new ScreenPoint();
            var rectangle = new Rectangle();
            if (ClientToScreen(window, out point) && GetClientRect(window, out rectangle))
            {
                point.X += GetX(rectangle, gamePosition.X);
                point.Y += GetY(rectangle, gamePosition.Y);
            }
            return point;
        }

        private static int GetX(Rectangle rectangle, double gameX)
        {
            var ratio = (4.0 / 3.0) / ((double)rectangle.Width / rectangle.Height);
            return (int)Helper.GetScaledXPos(gameX, rectangle.Width, ratio);
        }

        private static int GetY(Rectangle rectangle, double gameY)
        {
            return (int)(gameY * rectangle.Height);
        }
    }
}
