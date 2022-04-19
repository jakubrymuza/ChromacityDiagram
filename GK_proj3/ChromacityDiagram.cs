using System;
using System.Drawing;

namespace GK_proj3
{
    public class ChromacityDiagram
    {
        public bool DrawBackground = true;
        public CIEXYZ ChosenPoint;
        public bool sRGB
        {
            get => _sRGB;
            set
            {
                _sRGB = value;
                DrawGamutBitmap();
            }
        }

        public const int VisibleMin = 380;
        public const int VisibleMax = 780;

        private bool _sRGB = true;
        private readonly int _Width;
        private readonly int _Height;      
        private readonly int _Scale;
        private const int _PaddingX = 50;
        private const int _PaddingY = 50;
        private const int _PointSize = 10;
        private const double _MultiplierX = 0.74;
        private const double _MultiplierY = 0.84;

        private CIEXYZ[] _WavelengthsXYZ;      
        private Bitmap _DiagramBitmap;
        private Bitmap _BackgroundBitmap;
        private Bitmap _AxesBitmap;
        private Bitmap _GamutBitmap;


        public ChromacityDiagram(int width, int height, CIEXYZ[] wavelengthsXYZ)
        {
            _Width = width;
            _Height = height;

            _WavelengthsXYZ = wavelengthsXYZ;

            _Scale = Math.Min(width, height) - Math.Max(_PaddingX, _PaddingY);

            _DiagramBitmap = new Bitmap(width, height);
            DrawDiagramBitmap();

            LoadBackgroundBitmap();

            _AxesBitmap = new Bitmap(width, height);
            DrawAxesBitmap();
          
            DrawGamutBitmap();
        }

        public void Draw(Graphics g)
        {           
            if (DrawBackground)
                g.DrawImage(_BackgroundBitmap, new Point(_PaddingX, _DiagramBitmap.Height - _BackgroundBitmap.Height - _PaddingY));

            g.DrawImage(_DiagramBitmap, new Point(0, 0));

            g.DrawImage(_GamutBitmap, new Point(0, 0));

            g.DrawImage(_AxesBitmap, new Point(0, 0));

            DrawChosenPoint(g);
        }

        private static double[,] _sRGBGamutPoints = new double[3,2]
        {
            {0.64, 0.33 },
            {0.3, 0.6 },
            {0.15, 0.06 }
        };

        private static double[,] _WideGamutPoints = new double[3, 2]
        {
            {0.735, 0.265 },
            {0.115, 0.826 },
            {0.157, 0.018 }
        };

        private void DrawGamutBitmap()
        {
            _GamutBitmap = new Bitmap(_Width, _Height);
            var points = sRGB ? _sRGBGamutPoints : _WideGamutPoints;

            Graphics g = Graphics.FromImage(_GamutBitmap);

            for(int i = 0; i < 3; i++)
            {
                Point p1 = GetPointPosition(points[i, 0], points[i, 1]);
                Point p2 = GetPointPosition(points[(i + 1) % 3, 0], points[(i + 1) % 3, 1]);

                g.FillEllipse(Brushes.Black, Utils.GetCenteredSquare(p1, _PointSize));
                g.DrawLine(Pens.Black, p1, p2);
            }

            g.Dispose();
        }

        private void DrawDiagramBitmap()
        {
            Graphics g = Graphics.FromImage(_DiagramBitmap);
            for (int i = VisibleMin; i <= 700; ++i)
            {
                g.FillEllipse(new SolidBrush(_WavelengthsXYZ[i].GetRGBColor(sRGB)),
                    Utils.GetCenteredSquare(GetPointPosition(_WavelengthsXYZ[i]), _PointSize));
            }

            g.Dispose();
        }

        private Point GetPointPosition(CIEXYZ XYZ)
        {
            (double x, double y, _) = XYZ.Getxyz();

            return new Point(
                        (int)(x * _Scale) + _PaddingX,
                        _DiagramBitmap.Height - (int)(y * _Scale) - _PaddingY);
        }

        private Point GetPointPosition(double x, double y) => new Point(
                        (int)(x * _Scale) + _PaddingX,
                        _DiagramBitmap.Height - (int)(y * _Scale) - _PaddingY);
        

        private void LoadBackgroundBitmap()
        {
            Bitmap bitmap = new Bitmap(@"..\..\..\Data\Chromaticity_Diagram_Background2.png");
            _BackgroundBitmap = new Bitmap(bitmap, 
                (int)(_MultiplierX * _Scale), 
                (int)(_MultiplierY * _Scale));
        }

        private void DrawChosenPoint(Graphics g)
        {
            if (ChosenPoint == null)
                return;

            (double x, double y, _) = ChosenPoint.Getxyz();

            Point p = GetPointPosition(ChosenPoint);
            g.FillEllipse(Brushes.Black, Utils.GetCenteredSquare(p, _PointSize));

            string s = x.ToString("F") + ", " + y.ToString("F");
            g.DrawString(s, new Font("Arial", 12), Brushes.Black, p);
        }

        private const double _StartX = 0;
        private const double _IncrementX = 0.1;
        private const double _EndX = 1.09;
        private const double _StartY = 0;
        private const double _IncrementY = 0.1;
        private const double _EndY = 0.99;

        private void DrawAxesBitmap()
        {
            Utils.DrawAxes(_AxesBitmap, _PaddingX, _StartX, _IncrementX, _EndX, _PaddingY, _StartY, _IncrementY, _EndY);
        }
    }
}
