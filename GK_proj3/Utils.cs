using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace GK_proj3
{
    public static class Utils
    {
        public static float Distance(Point p1, Point p2)
        {
            int x = p1.X - p2.X;
            int y = p1.Y - p2.Y;
            return (float)Math.Sqrt(x * x + y * y);
        }

        public static (double u1, double u2, double u3) MultiplyMatrixVector3x3(double[,] matrix, double v1, double v2, double v3)
        {
            double u1 = (matrix[0, 0] * v1 + matrix[0, 1] * v2 + matrix[0, 2] * v3);
            double u2 = (matrix[1, 0] * v1 + matrix[1, 1] * v2 + matrix[1, 2] * v3);
            double u3 = (matrix[2, 0] * v1 + matrix[2, 1] * v2 + matrix[2, 2] * v3);

            return (u1, u2, u3);
        }

        /// <summary>
        /// returns a square given the center position and side length
        /// </summary>
        public static Rectangle GetCenteredSquare(Point center, int size) => new Rectangle(center.X - size / 2, center.Y - size / 2, size, size);

        public static void DrawAxes(Bitmap bitmap, int paddingX, double startX, double incrementX, double endX, int paddingY, double startY, double incrementY, double endY)
        {
            Graphics g = Graphics.FromImage(bitmap);

            Pen arrowPen = new Pen(Brushes.Black, 4);
            arrowPen.CustomEndCap = new AdjustableArrowCap(8, 8, true);
            Font font = new Font("Arial", 10);

            int lineLength = 10;

            // X Axis

            g.DrawLine(arrowPen, new Point(0, bitmap.Height - paddingY), new Point(bitmap.Width, bitmap.Height - paddingY));
       
            double curr = startX + incrementX;

            while(curr <= endX)
            {
                int scaledCurr = (int)((curr - startX) * (bitmap.Width - paddingX) / (endX - startX) + paddingX);

                g.DrawLine(new Pen(Brushes.Black, 2),
                    new Point(scaledCurr, bitmap.Height - paddingY - lineLength),
                    new Point(scaledCurr, bitmap.Height - paddingY + lineLength));

                g.DrawString(curr.ToString("F"), font, Brushes.Black, scaledCurr, bitmap.Height - paddingY);

                curr += incrementX;
            }

            // Y Axis

            g.DrawLine(arrowPen, new Point(paddingX, bitmap.Height), new Point(paddingX, 0));

            curr = startY + incrementY;

            while (curr <= endY)
            {
                int scaledCurr = (int)((curr - startY) * (bitmap.Height - paddingY) / (endY - startY));
                
                g.DrawLine(new Pen(Brushes.Black, 2),
                    new Point(paddingX - lineLength, bitmap.Height - scaledCurr - paddingY),
                    new Point(paddingX + lineLength, bitmap.Height - scaledCurr - paddingY));

                g.DrawString(curr.ToString("F"), font, Brushes.Black, 0, bitmap.Height - scaledCurr - paddingY);

                curr += incrementY;
            }
        }

        public static int Binomial(int n, int k)
        {
            int r = 1;

            if(k > n)
                return 0;

            for(int d = 1; d <= k; ++d)
            {
                r *= n--;
                r /= d;
            }

            return r;
        }

        public static Point MultiplyScalarPoint(Point p, double s) => new Point((int)(s * p.X), (int)(s * p.Y));

        public static Point AddPoints(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
    }
}
