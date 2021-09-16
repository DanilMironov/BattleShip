using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Views
{
    public static class DrawExtensions
    {
        private static Brush backBrush = new SolidBrush(Color.AntiqueWhite);
        private static Brush shipBrush = new SolidBrush(Color.FromArgb(109, 101, 82));
        private static Pen cellPen = new Pen(Color.Black, 1);
        private static Brush shotBrush = new SolidBrush(Color.FromArgb(11, 55, 0xAA));
        private static Brush conflictShipBrush = new SolidBrush(Color.FromArgb(0xFF, 0x88, 0x88));
        private static Pen shipPen = new Pen(Color.FromArgb(0x11, 0x55, 0xAA), 4);
        private static Pen lightShipPen = new Pen(Color.FromArgb(0xEE, 0xCC, 0x66), 4);

        public static void DrawBackground(this Graphics graphics, int width, int height)
        {
            graphics.FillRectangle(backBrush, 0, 0, width, height);
        }

        public static void DrawEmptyCell(this Graphics graphics, Rectangle rectangle)
        {
            graphics.DrawRectangle(cellPen, rectangle);
        }

        public static void DrawShipCell(this Graphics graphics, Rectangle rectangle,
            bool isShot = false, bool inConflict = false, bool useLight = false)
        {
            var brush = inConflict ? conflictShipBrush : shipBrush;
            var pen = useLight ? lightShipPen : shipPen;

            graphics.FillRectangle(brush, rectangle);
            graphics.DrawRectangle(pen, rectangle);

            if (isShot)
            {
                graphics.DrawLine(shipPen, rectangle.Left, rectangle.Top, rectangle.Right, rectangle.Bottom);
                graphics.DrawLine(shipPen, rectangle.Left, rectangle.Bottom, rectangle.Right, rectangle.Top);
            }
        }

        public static void DrawShotCell(this Graphics graphics, Rectangle rectangle)
        {
            graphics.FillEllipse(shotBrush,
                rectangle.X + 3 * rectangle.Width / 8,
                rectangle.Y + 3 * rectangle.Height / 8,
                rectangle.Width / 4,
                rectangle.Height / 4);
        }

    }
}
