using System;
using System.Drawing;
using System.Collections.Generic;

namespace GK_proj3
{
    public class ChromacityCurve
    {
        public int PointsCount
        {
            get => _PointsCount;
            set
            {
                _PointsCount = value;
                GenerateDefaultPoints();
            }
        }

        public const int VisibleMin = 380;
        public const int VisibleMax = 780;
        public bool PaintColors = true;
        public bool sRGB = true;

        private List<Point> _Points;
        private Bitmap _AxesBitmap;
        private CIEXYZ[] _WavelengthsXYZ;
        private int _PointsCount;
        private int _SelectedPointIndex = -1;
        private double k;

        private readonly int _Width;
        private readonly int _Height;

        private const int _PaddingX = 50;
        private const int _PaddingY = 50;
        private const int _PointSize = 10;
        private const int _DeafultPointCount = 5;

        public ChromacityCurve(int width, int height, CIEXYZ[] wavelengthsXYZ)
        {
            _Width = width;
            _Height = height;
            _WavelengthsXYZ = wavelengthsXYZ;

            PointsCount = _DeafultPointCount;

            CalculateK();

            _AxesBitmap = new Bitmap(width, height);
            DrawAxesBitmap();
        }

        public void Draw(Graphics g)
        {           
            DrawBezier(g);
            DrawPoints(g);
            g.DrawImage(_AxesBitmap, new Point(0, 0));
        }

        public CIEXYZ GetChosenPoint() //=> _ChosenPoint;
        {
            double X = 0, Y = 0, Z = 0;

            int nbPoint = _PointsCount - 1;
            Point p1 = _Points[0];
            Point p2;

            double step = 0.01;//1.0 / GetCurveSpan();

            for (double i = 0; i <= 1; i += step)
            {
                p2 = new Point(0, 0);
                for (int j = 0; j <= nbPoint; j++)
                {

                    p2 = Utils.AddPoints(p2,
                        Utils.MultiplyScalarPoint(_Points[j],
                            Utils.Binomial(nbPoint, j) * Math.Pow(1 - i, nbPoint - j) * Math.Pow(i, j)));
                }

                (double x1, double y1) = ScalePoint(p1);
                (double x2, double y2) = ScalePoint(p2);
                CIEXYZ v1 = _WavelengthsXYZ[(int)x1];
                CIEXYZ v2 = _WavelengthsXYZ[(int)x2];
                int h = Math.Abs(p2.X - p1.X);

                X += (v1.X * y1 + v2.X * y2) * h / 2;
                Y += (v1.Y * y1 + v2.Y * y2) * h / 2;
                Z += (v1.Z * y1 + v2.Z * y2) * h / 2;


                p1 = p2;
            }

            return new CIEXYZ(k * X, k * Y, k * Z);
        }

        public bool CheckHitboxes(Point p)
        {
            for (int i = 0; i < _PointsCount; ++i)
            {
                if(Utils.Distance(_Points[i], p) < _PointSize / 2)
                {
                    _SelectedPointIndex = i;
                    return true;
                }
            }

            return false;
        }

        public void ChangePosition(Point p)
        {
            if(CanMove(p))
                _Points[_SelectedPointIndex] = p;
        }

        private int GetCurveSpan() => Math.Abs(_Points[^1].X - _Points[0].X);

        private bool CanMove(Point p)
        {
            (double x, _) = ScalePoint(p);

            if (x < VisibleMin || x > VisibleMax)
                return false;

            return true;
        }

        private void DrawPoints(Graphics g)
        {
            foreach(var p in _Points)
                g.FillEllipse(Brushes.Black, Utils.GetCenteredSquare(p, _PointSize));
        }


        // https://stackoverflow.com/questions/15599766/n-th-order-bezier-curves
        private void DrawBezier(Graphics g)
        {            
            g.DrawLine(Pens.Black, new Point(_Points[0].X, _Height - _PaddingY), _Points[0]);
            g.DrawLine(Pens.Black, new Point(_Points[^1].X, _Height - _PaddingY), _Points[^1]);

            int nbPoint = _PointsCount - 1;
            Point p1 = _Points[0];
            Point p2;

            double step = 0.01;//1.0 / GetCurveSpan();

            Color c = GetChosenPoint().GetRGBColor(sRGB);

            for (double i = 0; i <= 1; i += step)
            {
                p2 = new Point(0, 0);
                for (int j = 0; j <= nbPoint; j++)
                {

                    p2 = Utils.AddPoints(p2,
                        Utils.MultiplyScalarPoint(_Points[j],
                            Utils.Binomial(nbPoint, j) * Math.Pow(1 - i, nbPoint - j) * Math.Pow(i, j)));
                }

                g.DrawLine(Pens.Black, p1, p2);


                // czesc labolatoryjna

                if(PaintColors)
                {
                    int stepPix = (int)(step * _Width) + 1;
                    g.FillRectangle(new SolidBrush(c), new Rectangle(p1.X, p1.Y, stepPix, _Height - (p1.Y + _PaddingY)));
                }


                p1 = p2;
            }
            g.DrawLine(Pens.Black, p1, _Points[^1]);
        }

        private void GenerateDefaultPoints()
        {
            _Points = new List<Point>();

            int spacing = (int)((_Width - _PaddingX) / (_PointsCount + 1));
            int x = spacing + _PaddingX;
            int y = (int)((_Height - _PaddingY) * 0.7);


            for (int i = 0; i < _PointsCount; ++i)
            {
                _Points.Add(new Point(x, y));
                x += spacing;
            }
        }

        private const double _StartX = 330;
        private const double _IncrementX = 50;
        private const double _EndX = 829;
        private const double _StartY = 0;
        private const double _IncrementY = 0.2;
        private const double _EndY = 1.8;

        private void DrawAxesBitmap()
        {
            Utils.DrawAxes(_AxesBitmap, _PaddingX, _StartX, _IncrementX, _EndX, _PaddingY, _StartY, _IncrementY, _EndY);
        }

        private (double, double) ScalePoint(Point p) => (
            (double)(p.X - _PaddingX) / (_Width - _PaddingX) * (_EndX - _StartX) + _StartX,
            (double)(p.Y - _PaddingY) / (_Height - _PaddingY) * (_EndY - _StartY) + _StartY
            );

        private void CalculateK()
        {
            double sum = 0;
            for (int i = VisibleMin; i < VisibleMax; ++i)
                sum += _WavelengthsXYZ[i].Y;

            k = 1 / sum;
        }

    }
}
